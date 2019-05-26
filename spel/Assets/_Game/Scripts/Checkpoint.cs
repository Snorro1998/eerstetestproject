using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "player" && !rb.useGravity)
        {
            Debug.Log("Mayo");
            rb.useGravity = true;
            other.transform.GetComponent<PlayerMovement>().startPosition = transform.position;
            FindObjectOfType<AudioManager>().playSound("Hayo");
            gameObject.GetComponent<AnimatedTexture>().index = 1;
        }
    }
}
