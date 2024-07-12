using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    GridSystem gridSystem;
    [SerializeField] Transform prefabTransform;
    void Start()
    {
        gridSystem = new GridSystem(10,10,2f);
        gridSystem.CreateDebugObjects(prefabTransform);
    }

    void Update()
    {
        Debug.Log(gridSystem.WorldToGrid(MousePosScript.GetMousePosition()).ToString());
    }
}
