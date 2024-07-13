using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    GridSystem gridSystem;
    [SerializeField] Transform prefabTransform;

    public static GridCreator Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        gridSystem = new GridSystem(10,10,2f);
        gridSystem.CreateDebugObjects(prefabTransform);
    }

    void Update()
    {
        Debug.Log(gridSystem.WorldToGrid(MousePosScript.GetMousePosition()).ToString());
    }

    public void SetUnitAtGridPosition(playerMovementScript unit,  Vector3 position)
    {
        GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        gridObject.SetUnit(unit);
    }
    public playerMovementScript GetUnitAtGridPosition(Vector3 position)
    {
        GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        return gridObject.GetUnit();
    }
}
