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
        //FindWithTag
        //FindObjectOfType<scrScore>().endLevel();
        GameController.GetComponent<Controller>().endLevel();
    }
}
