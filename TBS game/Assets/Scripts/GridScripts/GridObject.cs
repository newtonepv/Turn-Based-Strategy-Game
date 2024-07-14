using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class GridObject 
{
    GridSystem father;
    GridPos position;
    List<Unit> units;
    public List<Unit> GetUnitList()
    {
        return units;
    }
    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }
    public void RemoveUnit(Unit unit)
    {
        units.Remove(unit);
    }
    public GridObject(GridSystem father,GridPos position)
    {
        this.father = father;
        this.position = position;
        units = new List<Unit>();
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
