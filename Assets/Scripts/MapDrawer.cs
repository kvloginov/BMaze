using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapDrawer : MonoBehaviour
{
    public static int pixelsPerUnit = 16;

    public int width;
    public int yOffset;

    public int z;

    public GameObject hero;

    public float grassFrequency;

    // тайл, который будем рисовать
    public TileBase tile;
    // всякие разные тайлы
    public TileBase[] rareTiles;

    // тайлмап, на котором будем рисовать
    public Tilemap tilemap;

    // Идол!
    public GameObject idolPrefab;
    // TODO придумать название
    public int drawEverySec;
    public int idolsInRow;

    void Start()
    {
        InvokeRepeating("DrawIdols", 0, drawEverySec);
    }

    void Update()
    {
        var drawFrom = GetDrawFrom();

        DrawTiles(drawFrom);
    }

    private Vector3Int GetDrawFrom()
    {
        var heroPos = hero.transform.position;
        Vector3Int center = new Vector3Int(
            (int)Math.Floor(heroPos.x),
            (int)Math.Floor(heroPos.y),
            z);

        return center - new Vector3Int(width / 2, -yOffset, 0);
    }

    // костыльное быстррое решение
    private void DrawIdols()
    {
        var drawFrom = GetDrawFrom();

        for(int i = 0; i < idolsInRow; i++)
        {
            float xShift = width * Random.value;
            // MAgic number used :)
            float yShift = yOffset * 0.5f * Random.value;
            var idolPos = drawFrom + new Vector3(xShift, yShift, 0);
            Instantiate(idolPrefab, idolPos, Quaternion.identity);
        }
        

        Debug.Log("Dreaw IDOLS!1");
    }

    private void DrawTiles(Vector3Int drawFrom)
    {
        Vector3Int boundsSize = new Vector3Int(width, 1, 1);
        var bounds = new BoundsInt(drawFrom, boundsSize);

        var tileArray = generateTileArray(width, 1, 1);

        if (!tilemap.HasTile(drawFrom))
        {
            tilemap.SetTilesBlock(bounds, tileArray);
        }
    }

    private TileBase[] generateTileArray(int width, int height, int depth)
    {
        TileBase[] tileArray = new TileBase[width * 1 * 1];
        for (int index = 0; index < tileArray.Length; index++)
        {
            int range = (int)Math.Floor(rareTiles.Length / grassFrequency) + 1;

            var peek = Random.Range(0, range);
            tileArray[index] = peek < rareTiles.Length ? rareTiles[peek] : tile;
        }

        return tileArray;
    }

   
}
