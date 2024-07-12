using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectScript {
    GridSystem father;
    GridPos position;

    public GridObjectScript(GridSystem father,GridPos position) {

        this.father = father;
        this.position = position;
    }

}
