using UnityEngine;

public class scrEndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<scrScore>().endLevel();
    }
}
