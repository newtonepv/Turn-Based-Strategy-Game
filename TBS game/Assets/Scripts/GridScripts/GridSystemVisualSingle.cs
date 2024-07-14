using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisualSingle : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    void Start()
    {
    }


    void Update()
    {
        
    }

    public void SetMeshRenderer(bool active)
    {
        meshRenderer.enabled = active;
    }

}
