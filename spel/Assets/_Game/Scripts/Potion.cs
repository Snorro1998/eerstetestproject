using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool gravityUp = false;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            int dir = -1;
            if (gravityUp)
            {
                dir = 1;
            }
            //other.transform.GetComponent<Player_Movement>().gravDirection = dir;
            FindObjectOfType<PlayerMovement>().gravDirection = dir;
            moveAway();
        }
    }

    void moveAway()
    {
        transform.position = new Vector3(-100, 0, -100);
    }

    public void moveToStartPosition()
    {
        transform.position = startPosition;
    }
}
