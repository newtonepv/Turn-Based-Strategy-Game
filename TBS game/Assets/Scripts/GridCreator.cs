using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10,10,2f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gridSystem.WorldToGrid(MousePosScript.GetMousePosition()).ToString());
    }
}
