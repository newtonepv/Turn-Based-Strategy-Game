using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitActionControllerScript : MonoBehaviour
{
    [SerializeField] LayerMask groundPlane;
    [SerializeField] LayerMask unitLayer;
    [SerializeField] playerMovementScript selectedUnit;
    public static UnitActionControllerScript Instance { get; private set; }
    

    public event EventHandler OnUnitSelectedChange;
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
    private void Start()
    {

    }
    private void Update()
    {
        HandleActions();
    }
    void HandleActions()
    {
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

    private bool HandleUnitSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Instance.unitLayer))
        {
            if(hit.collider.TryGetComponent<playerMovementScript>(out playerMovementScript unit))
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
    private void SelectUnit(playerMovementScript Unit)
    {
        selectedUnit = Unit;
        OnUnitSelectedChange?.Invoke(this, EventArgs.Empty);
        
    }
    public playerMovementScript GetSelectedUnit()
    {
        return selectedUnit;
    }
    private void MooveUnit(Vector3 destination)
    {
        selectedUnit.SetDestination(destination);
        selectedUnit.SetRotationTowards(destination);
    }
}
