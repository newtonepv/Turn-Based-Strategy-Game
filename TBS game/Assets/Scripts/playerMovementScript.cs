using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    Vector3 destination;
    bool isMoving;
    Vector3 wantedForward;

    [SerializeField] float rotateSpeed;
    [SerializeField] float mooveSpeed;
    [SerializeField] float maxDistanceFromDestination;

    PlayerAnimatorScript playerAnimator;
    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimatorScript>();
        wantedForward = transform.forward;
        destination = transform.position;
    }
    void Start()
    {
    }

    void Update()
    {
        MoveOrNot();
        RotateOrNot();
    }
    private void RotateOrNot()
    {
        if ((wantedForward- transform.forward).magnitude > 0.1)
        {
            transform.forward = Vector3.Lerp(transform.forward, wantedForward, rotateSpeed * Time.deltaTime);
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
    

    public void SetRotationTowards(Vector3 mousepos)
    {
        wantedForward = (mousepos - transform.position).normalized;
    }

    void MoveOrNot()
    {

        Vector3 distance = (destination - transform.position);

        if (distance.magnitude > maxDistanceFromDestination)
        {
            SetMooving(true);
            Vector3 direction = distance.normalized;
            transform.position += mooveSpeed * Time.deltaTime * direction;
        }
        else
        {
            SetMooving(false);
            transform.position = destination;
        }


    }
    void SetMooving(bool isMoving)
    {
        this.isMoving = isMoving;
        if (isMoving)
        {
            playerAnimator.StartMoovingAnimation();
        }
        else
        {
            playerAnimator.StopMoovingAnimation();
        }

    }
}
