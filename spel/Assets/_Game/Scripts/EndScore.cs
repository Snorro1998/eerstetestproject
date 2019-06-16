using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    void Update()
    {
        Controller gameController = FindObjectOfType<Controller>();
        score = gameController.score;
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString() + " punten!";
        if (gameController.showScore)
        {
            gameController.showScore = false;
        }
    }
}
