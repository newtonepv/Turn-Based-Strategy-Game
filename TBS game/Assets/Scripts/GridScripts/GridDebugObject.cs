using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    GridObject gridObject;
    [SerializeField] TextMeshPro textMPro;
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    void SetText(string text)
    {
        this.textMPro.text = text;
    }

    public void Update() {

        SetText(gridObject.ToString());
    }
}
