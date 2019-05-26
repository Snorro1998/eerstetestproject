using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;

    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float distToGround = 0.5f;

    [HideInInspector]
    public Vector3 startPosition;
    public int maxHeight = 14;

    [HideInInspector]
    public int gravDirection = -1;

    private GameObject[] gameObjects;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        gameObjects = GameObject.FindGameObjectsWithTag("potion");
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, gravDirection * 9.81f * Mathf.Pow(rb.mass, 2), 0));

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            float jumpVelocity = Mathf.Clamp(rb.velocity.y + jumpSpeed * -gravDirection, -jumpSpeed, jumpSpeed);
            Vector3 velocity = new Vector3(0, jumpVelocity, 0);
            rb.velocity = velocity;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX * Time.deltaTime, 0, deltaY * Time.deltaTime);
        movement = transform.TransformDirection(movement);
        rb.MovePosition(transform.position + movement);

        if (transform.position.y < -1f && gravDirection == -1 || transform.position.y > maxHeight && gravDirection == 1)
        {
            respawn();
        }
    }

    public void respawn()
    {
        FindObjectOfType<AudioManager>().playSound("Dead");
        transform.position = startPosition;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<Potion>().moveToStartPosition();
        }
    }

    bool isGrounded()
    {
        int numRaysInRing = 8;
        float ringIncrement = 2f * Mathf.PI / numRaysInRing;

        Vector3 downWard = new Vector3(0, gravDirection, 0);

        if (Physics.Raycast(transform.position, downWard, distToGround))
        {
            return true;
        }

        for (int i = 0; i < numRaysInRing; i++)
        {
            if (Physics.Raycast(new Vector3(transform.position.x + Mathf.Cos(i * ringIncrement) * 0.5f, transform.position.y, transform.position.z + Mathf.Sin(i * ringIncrement) * 0.5f), /*Vector3.down*/downWard, distToGround))
            {
                return true;
            }
        }
        return false;
    }

}
