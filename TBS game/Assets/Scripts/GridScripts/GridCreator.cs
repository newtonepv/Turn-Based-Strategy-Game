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
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(prefabTransform);
    }
    void Start()
    {
    }

    void Update()
    {
    }

    public void SetUnitAtGridPosition(playerMovementScript unit, GridPos gridPos)
    {
        //GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        gridObject.AddUnit(unit);

    }
    /*public playerMovementScript GetUnitAtGridPosition(GridPos gridPos)
    {
        //GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        return gridObject.GetUnit();
    }*/
    public void ClearUnitAtGridPosition(playerMovementScript unit,GridPos gridPos)
    {

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        gridObject.RemoveUnit(unit);
    }
    public GridPos WorldToGrid(Vector3 position) => gridSystem.WorldToGrid(position);
}
