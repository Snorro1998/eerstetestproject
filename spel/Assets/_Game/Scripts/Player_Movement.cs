using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float distToGround = 0.5f;
    Rigidbody rb;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Vector3 jumpVelocity = new Vector3(0f, jumpSpeed, 0f);
            rb.velocity = rb.velocity + jumpVelocity;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX * Time.deltaTime, 0, deltaY * Time.deltaTime);
        movement = transform.TransformDirection(movement);
        rb.MovePosition(transform.position + movement);

        if (transform.position.y < -1f)
        {
            respawn();
        }
    }

    public void respawn()
    {
        FindObjectOfType<scrAudioManager>().playSound("Dead");
        this.transform.position = startPosition;
    }

    bool isGrounded()
    {
        return Physics.Raycast (transform.position, Vector3.down, distToGround);
    }

}
