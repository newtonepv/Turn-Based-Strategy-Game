using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit : MonoBehaviour
{
    MoveAction moveAction;
    SpinAction spinAction;
    private void Awake()
    {
    }
    void Start()
    {
        GridPos gridPos = GridCreator.Instance.WorldToGrid(transform.position);
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
    }
    public MoveAction GetMoveAction()
    {
        return moveAction;
    }
    public bool IsMoveActionActive()
    {
        return moveAction.IsActive();
    }
    public bool IsSpinActionActive()
    {
        return spinAction.IsActive();
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
    public void Move(Vector3 destination)
    {
        GridPos gridDestination = GridCreator.Instance.WorldToGrid(destination);
        Vector3 limitedDestination = GridCreator.Instance.GridToWorld(gridDestination);
        moveAction.Move(limitedDestination);
    }
    public void Spin()
    {
        spinAction.SetSpinning(true);
    }

    /*void ChangeGridPos(GridPos gridPos, GridPos destinationGridPos)
    {
        ClearPosOnGrid(gridPos);
        SetPosInGrid(destinationGridPos);
    }*/


}
