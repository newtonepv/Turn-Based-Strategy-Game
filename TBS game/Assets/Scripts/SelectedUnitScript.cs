
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SelectedUnitScript : MonoBehaviour
{
    [SerializeField] playerMovementScript unit;
    MeshRenderer meshRedner;
    private void Awake()
    {
        meshRedner = GetComponent<MeshRenderer>();
        SetMeshrendererActive(false);
    }
    public void SetMeshrendererActive(bool active)
    {
        meshRedner.enabled = active;
    }
    void Start()
    {
        UnitActionControllerScript.Instance.OnUnitSelectedChange += UnitActionController_OnAnyUnitSelection;
        UpdateMeshRender();
    }

    void UnitActionController_OnAnyUnitSelection(object sender, EventArgs empty)
    {
        UpdateMeshRender();
    }

    private void UpdateMeshRender()
    {
        if (UnitActionControllerScript.Instance.GetSelectedUnit() == unit)
        {
            SetMeshrendererActive(true);
        }
        else
        {
            SetMeshrendererActive(false);
        }
    }

    void Update()
    {
        
    }
}
