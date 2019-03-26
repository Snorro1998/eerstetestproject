﻿using UnityEngine;

public class scrDontDestroy : MonoBehaviour
{
    public string tagName = "GameController";

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagName);
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
