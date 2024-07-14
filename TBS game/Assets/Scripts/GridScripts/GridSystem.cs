using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem  {
    int height, width;
    float cellSize;
    GridObject[,] gridObject;
    GridDebugObject[,] gridDebugObjects;

    public GridSystem(int height, int width, float cellSize) {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;

        gridDebugObjects = new GridDebugObject[height, width];
        gridObject = new GridObject[height, width];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                gridObject[x,z] = new GridObject(this, new GridPos(x,z));
            }
        }
    }
    public Vector3 MiddleOfGridToWorldPos(int x, int z)
    {
        return (new Vector3(x,0,z) * cellSize)+new Vector3(cellSize/2,0,cellSize/2);
    }
    public Vector3 StartOfGridToWorldPos(int x, int z)
    {
        return (new Vector3(x, 0, z) * cellSize);
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
                                                             MiddleOfGridToWorldPos(x, z),
                                                             Quaternion.identity);

                //GridDebugObject == the object with tmpro
                GridDebugObject gridDebugObject = transform.gameObject.GetComponent<GridDebugObject>();

                //makes the text be: gridobject.ToString()
                gridDebugObject.SetGridObject(GetGridObjectFromGrid(x,z));

                gridDebugObjects[x,z] = gridDebugObject;

            }
        }
    }

    public GridObject GetGridObjectFromGrid(int x, int z)
    {
        return gridObject[x, z];
    }

    public GridDebugObject GetGridDebugObjectFromGrid(int x, int z)
    {
        return gridDebugObjects[x, z];
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeigth()
    {
        return height;
    }

    public bool GridPositionExist(int x, int z)
    {
        return  x >= 0 && z >= 0
                &&
                x < width && z < height;
    }
    public bool HasUnitOnGridPos(int x, int z)
    {
        if (GridPositionExist(x, z))
        {
            GridObject gridObject = GetGridObjectFromGrid(x, z);
            if (gridObject.GetUnitList().Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else {  return false; }
    }
}
