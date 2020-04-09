using System;
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

    void Start()
    {

    }

    // По-хорошему нужно отрисовывать редко, а не тысячу раз в секунду
    void Update()
    {
        var heroPos = hero.transform.position;
        Vector3Int center = new Vector3Int(
            (int)Math.Floor(heroPos.x),
            (int)Math.Floor(heroPos.y),
            z);

        Vector3Int drawFrom = center - new Vector3Int(width / 2, -yOffset, 0);

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
