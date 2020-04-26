using System;
using System.Collections;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapDrawer : MonoBehaviour
{
    public LevelOptions levelOptions;
    
    [Header("Насколько выше от игрока рисовать поле")]
    public int yOffset;

    public GameObject hero;
    
    [Range(0, 1)]
    public float grassFrequency;

    // тайлы, который будем рисовать
    public TileBase groundTile;
    public TileBase leftCliffTile;
    public TileBase rightCliffTile;
    // всякие разные тайлы
    public TileBase[] rareTiles;

    // тайлмап, на котором будем рисовать
    public Tilemap groundTilemap;
    // тайлмап, на котором будем рисовать края уровня
    public Tilemap сollidebleTilemap;

    // Идол!
    public GameObject idolPrefab;
    // TODO придумать название
    public int drawEverySec;
    public int idolsInRow;

    void Start()
    {
        // убрать идолов в другой скрипт
        //InvokeRepeating("DrawIdols", 0, drawEverySec);
    }

    void Update()
    {
        var drawFrom = GetDrawFrom();

        DrawTiles(drawFrom);
    }

    private Vector3Int GetDrawFrom()
    {
        var heroPos = hero.transform.position;
        int heroY = (int)Math.Floor(heroPos.y);


        return new Vector3Int(levelOptions.LevelStartX, heroY + yOffset, 0);
    }

    // костыльное быстррое решение
    private void DrawIdols()
    {
        var drawFrom = GetDrawFrom();

        for(int i = 0; i < idolsInRow; i++)
        {
            float xShift = (float)Math.Floor(levelOptions.GetWidth() * Random.value);
            // MAgic number used :)
            float yShift = (float)Math.Floor(yOffset * 0.5f * Random.value);
            var idolPos = drawFrom + new Vector3(xShift, yShift, 0);
            Instantiate(idolPrefab, idolPos, Quaternion.identity);
        }
    }

    private void DrawTiles(Vector3Int drawFrom)
    {
        Vector3Int boundsSize = new Vector3Int(levelOptions.GetWidth(), 1, 1);
        var bounds = new BoundsInt(drawFrom, boundsSize);

        var bottomTileArray = GenerateBottomTileArray(levelOptions.GetWidth(), 1);
        var topTileArray = GenerateTopTileArray(levelOptions.GetWidth(), 1);

        if (!groundTilemap.HasTile(drawFrom))
        {
            groundTilemap.SetTilesBlock(bounds, bottomTileArray);
            сollidebleTilemap.SetTilesBlock(bounds, topTileArray);
        }
    }


    private TileBase[] GenerateTopTileArray(int width, int height)
    {
        // не оч оптамиально, ну да ладно :)
        TileBase[] tileArray = new TileBase[width * height];
        // Если рисуем слева
        for (int i = 0; i < tileArray.Length; i += width) 
        {
            tileArray[i] = leftCliffTile;
        }
        // Если рисуем справа
        for (int i = width - 1; i < tileArray.Length; i += width)
        {
            tileArray[i] = rightCliffTile;
        }
        return tileArray;
    }

    private TileBase[] GenerateBottomTileArray(int width, int height)
    {
        TileBase[] tileArray = new TileBase[width * height];
        int rareTilesCount = (int)Math.Floor(rareTiles.Length / grassFrequency) + 1;
        
        // не обращаем внимания, в каком месте рисуем
        for (int index = 0; index < tileArray.Length; index++)
        {
            var peek = Random.Range(0, rareTilesCount);
            tileArray[index] = peek < rareTiles.Length ? rareTiles[peek] : groundTile;   
        }
        return tileArray;
    }
}
