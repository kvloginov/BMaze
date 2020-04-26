using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdolSpawner : MonoBehaviour
{

    public LevelOptions levelOptions;
    [Header("Насколько выше от игрока рисовать идолов")]
    public int yOffset;

    public Transform heroTransform;

    // Идол!
    public GameObject idolPrefab;
    // TODO придумать название
    public int drawEverySec;
    public int idolsInRow;

    void Start()
    {
        //убрать идолов в другой скрипт
        InvokeRepeating("DrawIdols", 0, drawEverySec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3Int GetDrawFrom()
    {
        var heroPos = heroTransform.position;
        int heroY = (int)Math.Floor(heroPos.y);

        return new Vector3Int(levelOptions.LevelStartX, heroY + yOffset, 0);
    }

    // костыльное быстррое решение
    private void DrawIdols()
    {
        var drawFrom = GetDrawFrom();

        for (int i = 0; i < idolsInRow; i++)
        {
            // +1 и -2 исключают появление идолов на краю 
            float xShift = 1 + (float)Math.Floor((levelOptions.GetWidth() - 2) * Random.value);
            // MAgic number used :)
            float yShift = (float)Math.Floor(yOffset * 0.5f * Random.value);
            var idolPos = drawFrom + new Vector3(xShift, yShift, 0);
            Instantiate(idolPrefab, idolPos, Quaternion.identity);
        }
    }
}
