using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float zoomAmount;
    [SerializeField] float zoomSpeed;
    [SerializeField] float zoomMinBound;
    [SerializeField] float zoomMaxBound;
    Vector3 wantedFollowOfset;
    CinemachineTransposer transposer;
    void Start()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        wantedFollowOfset = transposer.m_FollowOffset;
    }
    void Update()
    {
        HandleMoovement();
        HandleRotation();
        HandleZoom();
    }
    void HandleMoovement()
    {
        Vector3 moovement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            moovement.z = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moovement.z = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moovement.x = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moovement.x = -1;
        }

        float mooveSpeed = 10;
        moovement = transform.forward * moovement.z + transform.right * moovement.x;
        transform.position += moovement * mooveSpeed * Time.deltaTime;
    }
    void HandleRotation()
    {
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

        transform.eulerAngles += rotation * rotationSpeed * Time.deltaTime;
    }
    void HandleZoom()
    {
        

        if (Input.mouseScrollDelta.y > 0)
        {
            wantedFollowOfset.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            wantedFollowOfset.y += zoomAmount;
        }

        wantedFollowOfset.y = Mathf.Clamp(wantedFollowOfset.y, zoomMinBound, zoomMaxBound);

        if (Vector3.Distance(transposer.m_FollowOffset, wantedFollowOfset) < 0.01)
        {
            transposer.m_FollowOffset = wantedFollowOfset;
        }
        else
        {

            transposer.m_FollowOffset =
                Vector3.Lerp(transposer.m_FollowOffset, wantedFollowOfset, (Time.deltaTime * zoomSpeed));
        }
    }
}
