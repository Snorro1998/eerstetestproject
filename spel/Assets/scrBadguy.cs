using UnityEngine;

public class scrBadguy : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += movement;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "walls")
        {
            speed *= -1;
        }
        else if (other.tag == "player")
        {
            FindObjectOfType<Player_Movement>().respawn();
        }
    }
}
