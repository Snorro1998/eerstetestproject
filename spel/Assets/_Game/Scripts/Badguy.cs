using UnityEngine;

public class Badguy : MonoBehaviour
{
    public float speed = 5;
    public enum MoveDirection {
        Horizontal,
        Vertical
    }
    public MoveDirection moveDirection = MoveDirection.Horizontal;

    private float ySpeed = 0;
    private float zSpeed = 0;

    //x bij verticaal, y bij horizontaal
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        xRotation = Mathf.Round(transform.eulerAngles.x);
        yRotation = Mathf.Round(transform.eulerAngles.y);

        switch (moveDirection)
        {
            case MoveDirection.Horizontal:
                zSpeed = speed * Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
                break;
            case MoveDirection.Vertical:
                ySpeed = speed * Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.x);
                break;
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "walls")
        {
            if (moveDirection == MoveDirection.Horizontal)
            {
                yRotation = (yRotation + 180) % 360;
            }
            else
            {
                xRotation = (xRotation + 180) % 360;
            }

            transform.eulerAngles = new Vector3(xRotation/*transform.eulerAngles.x*/, yRotation, transform.eulerAngles.z);
        }
        else if (other.tag == "player")
        {
            FindObjectOfType<PlayerMovement>().respawn();
        }
    }
}
