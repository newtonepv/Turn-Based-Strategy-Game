using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosScript : MonoBehaviour
{
    [SerializeField] LayerMask groundPlane;
    static MousePosScript instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        MoveToMousePos();
        
    }

    private void MoveToMousePos()
    { 
       transform.position = MousePosScript.GetMousePosition();
    }
    public static Vector3 GetMousePosition()
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
 }
