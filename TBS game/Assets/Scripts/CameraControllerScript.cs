using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float zoomspeed;
    [SerializeField] float zoomMinBound;
    [SerializeField] float zoomMaxBound;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 moovement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            moovement.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moovement.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moovement.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moovement.x = 1;
        }

        float mooveSpeed = 10;
        moovement += Vector3.forward * moovement.z + Vector3.right * moovement.x;
        transform.position += moovement*mooveSpeed*Time.deltaTime;


        Vector3 rotation = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.E))
        {
            rotation.y = 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rotation.y = -1;
        }
        float rotationSpeed = 100;

        transform.eulerAngles += rotation* rotationSpeed*Time.deltaTime;


        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        Debug.Log(Input.mouseScrollDelta.y);

        Vector3 offset = transposer.m_FollowOffset;
        if(Input.mouseScrollDelta.y >0)
        {
            offset.y -= zoomspeed;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            offset.y += zoomspeed;
        }
        offset.y = Mathf.Clamp(offset.y,zoomMinBound,zoomMaxBound);
        transposer.m_FollowOffset = offset;
    }
}
