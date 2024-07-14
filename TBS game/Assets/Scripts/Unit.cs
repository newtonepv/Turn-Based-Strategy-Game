using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit : MonoBehaviour
{
    MoveAction moveAction;
    SpinAction spinAction;

    public delegate void OnMoveActionCompleteDelegate(bool isBusy);
    public delegate void OnSpinActionCompleteDelegate(bool isBusy);

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
    public SpinAction GetSpinAction()
    {
        return spinAction;
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
    



}
