using UnityEngine;
using UnityEngine.SceneManagement;

public class scrScore : MonoBehaviour
{
    public int score = 0;
    /*
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/

    public void endLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("MISSHION COMPREE");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,200), "Score: " + score);
    }
}
