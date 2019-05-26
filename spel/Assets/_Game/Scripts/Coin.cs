using UnityEngine;


public class Coin : MonoBehaviour
{
    public int value;
    public string sound;

    private void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            FindObjectOfType<AudioManager>().playSound(sound);
            FindObjectOfType<Controller>().score += value;
            Destroy(gameObject);
        }
    }
}
