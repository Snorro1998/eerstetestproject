using UnityEngine;


public class scrCoin : MonoBehaviour
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
            FindObjectOfType<scrAudioManager>().playSound(sound);
            FindObjectOfType<scrScore>().score += value;
            Destroy(gameObject);
        }
    }
}
