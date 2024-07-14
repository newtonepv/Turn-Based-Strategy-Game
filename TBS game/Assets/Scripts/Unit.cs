using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit : MonoBehaviour
{
    [SerializeField] public string UnitName;
    MoveAction moveAction;
    private void Awake()
    {
    }
    void Start()
    {
        GridPos gridPos = GridCreator.Instance.WorldToGrid(transform.position);
        moveAction = GetComponent<MoveAction>();
    }
    public MoveAction GetMoveAction()
    {
        return moveAction;
    }


    public GridPos GetGridPos()
    {
        return GridCreator.Instance.WorldToGrid(transform.position);
    }


    void SetPosInGrid(GridPos gridPos)
    {
        GridCreator.Instance.AddUnitAtGridPosition(this, gridPos);
    }

    void ClearPosOnGrid(GridPos gridPos)
    {
        GridCreator.Instance.RemoveUnitAtGridPosition(this, gridPos);
    }
    public void SetPosInGrid(Vector3 pos)
    {
        GridPos gridPos = GridCreator.Instance.WorldToGrid(pos);
        GridCreator.Instance.AddUnitAtGridPosition(this, gridPos);
    }

    public void ClearPosInGrid(Vector3 pos)
    {
        GridPos gridPos = GridCreator.Instance.WorldToGrid(pos);
        GridCreator.Instance.RemoveUnitAtGridPosition(this, gridPos);
    }
    void Update()
    {
    }
    public void SetDestination(Vector3 destination)
    {
        GridPos GridDestination = GridCreator.Instance.WorldToGrid(destination);
        moveAction.SetDestination(GridCreator.Instance.GridToWorld(GridDestination));
    }
    public void SetRotationTowards(Vector3 mousepos)
    {
        moveAction.SetRotationTowards((mousepos - transform.position).normalized);
    }

    /*void ChangeGridPos(GridPos gridPos, GridPos destinationGridPos)
    {
        ClearPosOnGrid(gridPos);
        SetPosInGrid(destinationGridPos);
    }*/

    
}
