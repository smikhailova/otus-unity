using System;
using System.Collections.Generic;
using UnityEngine;

public static class Map
{
    public static CellType[,] Field { get; private set; }

    private static int _worldWidth;
    private static int _worldHeight;


    public static void Init(List<GameObject> items, int WorldWidth, int WorldHeight)
    {
        _worldWidth = WorldWidth;
        _worldHeight = WorldHeight;

        Field = new CellType[_worldWidth, _worldHeight];

        foreach (GameObject item in items)
        {
            Field[(int)item.transform.position.x, (int)item.transform.position.z] =
                (CellType)Enum.Parse(typeof(CellType), item.tag);
        }
    }

    public static bool Exist(Vector3Int position)
    {
        if (
            position.x >= 0 &&
            position.x < _worldWidth &&
            position.z >= 0 &&
            position.z < _worldHeight
        ) return true;

        return false;
    }
}