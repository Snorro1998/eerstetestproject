using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    /*	
        public float speed = 6.0f;
        public float gravity = -9.8f;

        private float distToGround = 1.0f;
        Rigidbody rb;

        Vector3 startPosition;
        //Quaternion startRotation;

        private CharacterController _charCont;


        // Start is called before the first frame update
        void Start()
        {
            startPosition = transform.position;
            //startRotation = transform.rotation;
            rb = GetComponent<Rigidbody> ();
            _charCont = GetComponent<CharacterController> ();
        }

        // Update is called once per frame
        void Update()
        {

            Debug.Log(isGrounded());

            if (Input.GetKey(KeyCode.Space) && isGrounded())
            {
                Debug.Log("aaaah");
                Vector3 jumpVelocity = new Vector3(0f, speed, 0f);
                rb.velocity = rb.velocity + jumpVelocity;
            }

            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude (movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charCont.Move(movement);



            if (transform.position.y < -1f) {
                respawn();
            }
        }

        void respawn() {
            this.transform.position = startPosition;
        }

        bool isGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, distToGround);
        }*/


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
        //Debug.Log(isGrounded());

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
