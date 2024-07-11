using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitActionControllerScript : MonoBehaviour
{
    [SerializeField] LayerMask groundPlane;
    [SerializeField] LayerMask unitLayer;
    [SerializeField] static playerMovementScript selectedUnit;
    static UnitActionControllerScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
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
    static void HandleClickActions()
    {
        if (HandleUnitSelect())
        {

        }
        else
        {
            HandleMooveUnit();
        }


    }

    private static bool HandleUnitSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, instance.unitLayer))
        {
            if(hit.collider.TryGetComponent<playerMovementScript>(out playerMovementScript unit))
            {
                selectedUnit = unit;
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

    private static void HandleMooveUnit()
    {
        MooveUnit(GetMousePosition());
    }

    private static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, instance.groundPlane))
        {
            return hit.point;
        }
        else
        {
            return instance.transform.position;
        }
    }
    private void SelectUnit(playerMovementScript Unit)
    {
            selectedUnit = Unit;
    }

    public static void MooveUnit(Vector3 destination)
    {
            selectedUnit.SetDestination(destination);
            selectedUnit.SetRotationTowards(destination);
    }
}
