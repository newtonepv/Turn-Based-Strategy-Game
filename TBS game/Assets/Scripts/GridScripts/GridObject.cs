using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class GridObject 
{
    GridSystem father;
    GridPos position;
    List<playerMovementScript> units;
    public playerMovementScript GetUnit()
    {
        return units[1];
    }
    public void AddUnit(playerMovementScript unit)
    {
        units.Add(unit);
    }
    public void RemoveUnit(playerMovementScript unit)
    {
        units.Remove(unit);
    }
    public GridObject(GridSystem father,GridPos position)
    {
        this.father = father;
        this.position = position;
        units = new List<playerMovementScript>();
    }

    private GridPos GetPosition()
    {
    return position;
    }

    public override string ToString()
    {
        position = GetPosition();
        return "x:" + position.x+" z:"+position.z+"\n unit?:" + units.Count;
    }
}
