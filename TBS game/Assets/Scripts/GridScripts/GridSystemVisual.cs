using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] Transform gridSystemVisualSinglePrefab;

    int width, heigth;

    GridSystemVisualSingle[,] gridSystemVisualSingle;
    public static GridSystemVisual Instance { get; private set; }
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

    void Start()
    {
        width = GridCreator.Instance.GetWidth();
        heigth = GridCreator.Instance.GetHeigth();

        gridSystemVisualSingle = new GridSystemVisualSingle[width, heigth];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < heigth; z++)
            {
                Transform instance = Instantiate(gridSystemVisualSinglePrefab, GridCreator.Instance.GridToWorld(new GridPos(x, z)), Quaternion.identity);

                gridSystemVisualSingle[x, z] = instance.GetComponent<GridSystemVisualSingle>();

            }
        }
    }

    public void ClearAll()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < heigth; z++)
            {

                gridSystemVisualSingle[x, z].SetMeshRenderer(false);

            }
        }
    }
    public void ActivateConjunt(List<GridPos> posLis)
    {
        foreach (GridPos pos in posLis)
        {
            gridSystemVisualSingle[pos.x, pos.z].SetMeshRenderer(true);
        }
    }
    void Update()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {

        ClearAll();
        ActivateConjunt(
        UnitActionControllerScript.Instance.GetSelectedUnit().GetMoveAction().GetActualActionValidGridPosList());
    }
}
