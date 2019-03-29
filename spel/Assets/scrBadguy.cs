using UnityEngine;

public class scrBadguy : MonoBehaviour
{
    public float speed = 5;
    public GameObject followObject;

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag.Equals("player"))
            {
                followObject = hit.transform.gameObject;
                //Debug.Log("Ik zie de speler!");
            }
            else
            {
                followObject = null;
            }

        }

        /*RaycastHit Ray;
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out Ray))
        {
        }*/

        float zSpeed = speed * Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
        //Debug.Log("yRotation: " + transform.eulerAngles.y + ", zSpeed: " + zSpeed);
        Vector3 movement = new Vector3(0, 0, zSpeed * Time.deltaTime);
        transform.position += movement;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "walls")
        {
            float yRotation = Mathf.Round(transform.eulerAngles.y);
            yRotation = (yRotation + 180) % 360;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
        else if (other.tag == "player")
        {
            FindObjectOfType<Player_Movement>().respawn();
        }
    }
}
