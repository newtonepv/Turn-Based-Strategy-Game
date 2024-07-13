using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class GridObject : MonoBehaviour
{
    GridSystem father;
    GridPos position;
    playerMovementScript unit;
    public playerMovementScript GetUnit()
    {
        return unit;
    }
    public void SetUnit(playerMovementScript unit)
    {
        this.unit = unit;
    }
    public GridObject(GridSystem father,GridPos position)
    {
        this.father = father;
        this.position = position;
    }
    public GridPos GetPosition()
    {

    return position;
    }
    public override string ToString()
    {
        position = GetPosition();
        return "x:" + position.x+" z:"+position.z+"\n unit?:" + unit;
    }
}
