using System;
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

    // uber-optimization
    // положение персонажа при последнем рисовании новых тайлов
    private Vector3 lastDrawHeroPos;

    private void Start()
    {
        lastDrawHeroPos = hero.transform.position - new Vector3(0, levelOptions.ChunkSize, 0);
    }

    void Update()
    {
        // рисуем каждые chunksize юнитов
        if (Math.Abs(hero.transform.position.y - lastDrawHeroPos.y) > levelOptions.ChunkSize) {
            lastDrawHeroPos = hero.transform.position;
            var drawFrom = GetDrawFrom();
            DrawTiles(drawFrom);
        }
    }

    private Vector3Int GetDrawFrom()
    {
        var heroPos = hero.transform.position;
        int heroY = (int)Math.Floor(heroPos.y);

        return new Vector3Int(levelOptions.LevelStartX, heroY + yOffset, 0);
    }

    private void DrawTiles(Vector3Int drawFrom)
    {
        
        //if (groundTilemap.HasTile(drawFrom))
        //{
        //    return;
        //}

        Vector3Int boundsSize = new Vector3Int(levelOptions.GetWidth(), levelOptions.ChunkSize, 1);
        BoundsInt bounds = new BoundsInt(drawFrom, boundsSize);

        var bottomTileArray = GenerateBottomTileArray(levelOptions.GetWidth(), levelOptions.ChunkSize);
        var topTileArray = GenerateTopTileArray(levelOptions.GetWidth(), levelOptions.ChunkSize);
       
       groundTilemap.SetTilesBlock(bounds, bottomTileArray);
       сollidebleTilemap.SetTilesBlock(bounds, topTileArray);
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
