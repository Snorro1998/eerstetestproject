using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrScore : MonoBehaviour
{
    public int score = 0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,200), "Score: " + score);
    }
}
