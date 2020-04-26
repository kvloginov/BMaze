using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOptions : MonoBehaviour
{

    public int LevelStartX;
    public int LevelEndX;
    public int PixelsPerUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetWidth()
    {
        return LevelEndX - LevelStartX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
