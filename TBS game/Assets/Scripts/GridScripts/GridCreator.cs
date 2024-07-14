using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    GridSystem gridSystem;
    [SerializeField] Transform prefabTransform;
    [SerializeField] Vector2 gridZise;
    [SerializeField] float gridCellZise;
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
        gridSystem = new GridSystem(Mathf.RoundToInt(gridZise.x), Mathf.RoundToInt(gridZise.y), gridCellZise);
        gridSystem.CreateDebugObjects(prefabTransform);
    }
    void Start()
    {
    }

    void Update()
    {
    }

    public void AddUnitAtGridPosition(Unit unit, GridPos gridPos)
    {
        //GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        gridObject.AddUnit(unit);

    }
    public List<Unit> GetUnitAtGridPosition(GridPos gridPos)
    {
        //GridPos gridPos = gridSystem.WorldToGrid(position);

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        return gridObject.GetUnitList();
    }
    public void RemoveUnitAtGridPosition(Unit unit,GridPos gridPos)
    {

        GridObject gridObject = gridSystem.GetGridObjectFromGrid(gridPos.x, gridPos.z);

        gridObject.RemoveUnit(unit);
    }
    public GridPos WorldToGrid(Vector3 position) => gridSystem.WorldToGrid(position);

    public Vector3 GridToWorld(GridPos gridPos) => gridSystem.MiddleOfGridToWorldPos(gridPos.x, gridPos.z);

    public bool GridPositionExist(GridPos gridPos) => gridSystem.GridPositionExist(gridPos.x, gridPos.z);
    public bool HasUnitOnGridPos(GridPos gridPos) => gridSystem.HasUnitOnGridPos(gridPos.x, gridPos.z);
}
