using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public bool showScore = true;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }

    public void endLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Level complete!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnGUI()
    {
        if (showScore)
        {
            GUIStyle style = GUI.skin.GetStyle("label");
            style.fontSize = 30;

            GUI.Label(new Rect(10, 10, 300, 80), "Highscore: " + highScore);
            GUI.Label(new Rect(10, 40, 300, 80), "Score: " + score);
        }
    }
}
