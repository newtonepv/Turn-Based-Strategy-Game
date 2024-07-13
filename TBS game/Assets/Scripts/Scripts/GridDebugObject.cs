using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GridDebugObject : MonoBehaviour
{
    GridObject gridObject;
    [SerializeField] TextMeshPro text;
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        SetText(gridObject.ToString());
    }
    void SetText(string text)
    {
        this.text.text = text;
    }
}
