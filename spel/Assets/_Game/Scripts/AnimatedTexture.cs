using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    public int columns = 2;
    public int rows = 2;
    public float framesPerSecond = 10f;
    private Renderer rend;
    public int index = 0;
    private int indexPrev = 0;
    

    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        Vector2 size = new Vector2(1f / columns, 1f / rows); rend.sharedMaterial.SetTextureScale("_MainTex", size);
        rend.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(0,0));
    }

    private void Update()
    {
        if (framesPerSecond != 0)
        {
            index = (int)(Time.time * framesPerSecond) % (rows * columns);
        }
        
        if (indexPrev != index)
        {
            Vector2 offset = new Vector2((float)index / columns - (index / columns), (index / columns) / (float)rows);
            rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
            indexPrev = index;
        }   
    }
}
