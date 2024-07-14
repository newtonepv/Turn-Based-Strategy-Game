using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitActionControllerScript : MonoBehaviour
{
    [SerializeField] LayerMask groundPlane;
    [SerializeField] LayerMask unitLayer;
    [SerializeField] Unit selectedUnit;
    public static UnitActionControllerScript Instance { get; private set; }

    bool isBusy;
    public event EventHandler OnUnitSelectedChange;
    private void Awake()
    {
        isBusy = false;
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
    void SetIsBusy(bool isBusy)
    {
        this.isBusy = isBusy;
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (isBusy)
        {
            return;
        }
        
        HandleActions();
    }
    void HandleActions()
    {

        HandleSpinUnit();
        if (Input.GetMouseButtonDown(0))
        {
            
            HandleClickActions();

        }
    }
    void HandleClickActions()
    {
        if (HandleUnitSelect())
        {

        }
        else
        {
            HandleMooveUnit();
        }


    }

    private void HandleSpinUnit()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpinUnit();
        }
    }

    private void SpinUnit()
    {
        isBusy=true;
        selectedUnit.GetSpinAction().SetSpinning(true,SetIsBusy);
    }

    /*private bool AnyActiveAction()
    {
        return selectedUnit.IsSpinActionActive() || selectedUnit.IsMoveActionActive();
    }*/
    private bool HandleUnitSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Instance.unitLayer))
        {
            if(hit.collider.TryGetComponent<Unit>(out Unit unit))
            {
                SelectUnit(unit);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    private void HandleMooveUnit()
    {
            MooveUnit(GetMousePosition());
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Instance.groundPlane))
        {
            return hit.point;
        }
        else
        {
            return Instance.transform.position;
        }
    }
    private void SelectUnit(Unit unit)
    {
        selectedUnit = unit;
        
        OnUnitSelectedChange?.Invoke(this, EventArgs.Empty);
        
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    private void MooveUnit(Vector3 destination)
    {
        if (selectedUnit.TryGetComponent<MoveAction>(out MoveAction mooveAction))
        {

            isBusy = true;
            GridPos gridDestination = GridCreator.Instance.WorldToGrid(destination);
            Vector3 limitedDestination = GridCreator.Instance.GridToWorld(gridDestination);
            selectedUnit.GetMoveAction().Move(limitedDestination, SetIsBusy);
        }
    }
}
