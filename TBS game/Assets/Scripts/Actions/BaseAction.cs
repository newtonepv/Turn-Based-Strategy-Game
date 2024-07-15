using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected bool isActive;
    protected Unit unit;
    protected Action<bool> onActionCompleteDelegate;
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
    public bool IsActive()
    {
    return isActive; 
    }
}
