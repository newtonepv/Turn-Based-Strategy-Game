using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem {
    int height, width;
    float cellSize;
    GridObjectScript[,] gridObject;

    public GridSystem(int height, int width, float cellSize) {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;

        gridObject = new GridObjectScript[height, width];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                gridObject[x,z] = new GridObjectScript(this, new GridPos(x,z));
            }
        }
    }
    public Vector3 GridToWorldPos(int x, int z)
    {
        return new Vector3(x,0,z) * cellSize;
    }
    public GridPos WorldToGrid(Vector3 vector)
    {
        return new GridPos(
               (int)Math.Floor(vector.x/cellSize),
               (int)Math.Floor(vector.z/cellSize)
                           );
    }
    public void CreateDebugObjects(Transform prefab)
    {
        for(int x =0; x < width; x++)
        {
            for(int z=0; z<height; z++)
            {
                Transform transform = GameObject.Instantiate(prefab,
                                                             GridToWorldPos(x, z),
                                                             Quaternion.identity);

            }
        }
    }
}
