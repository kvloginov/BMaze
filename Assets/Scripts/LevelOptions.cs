using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOptions : MonoBehaviour
{

    public int LevelStartX;
    public int LevelEndX;
    public int PixelsPerUnit;
    public int ChunkSize = 64;
    
    [Header("Указывает максимально возможное кол-во очков, при котором игра перестанет усложняться по animation curves")]
    [Tooltip("Указывает максимально возможное кол-во очков, при котором игра перестанет усложняться по animation curves")]
    public int MaxLevelScore;

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
