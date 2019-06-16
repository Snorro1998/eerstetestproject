using UnityEngine;

public class EndLevel : MonoBehaviour
{
    GameObject GameController;

    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameController.GetComponent<Controller>().endLevel();
    }
}
