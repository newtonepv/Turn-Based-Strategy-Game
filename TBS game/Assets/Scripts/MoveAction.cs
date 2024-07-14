using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    bool isMoving;
    Vector3 wantedForward;
    Vector3 destination;

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
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if(TryGetComponent<playerMovementScript>(out playerMovementScript unit))
        {
            unit.ClearPosInGrid(transform.position);
        }
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

        if (unit)
        {
            unit.SetPosInGrid(transform.position);
        }
    }
    private void HandleRotation()
    {
        if ((wantedForward - transform.forward).magnitude > 0.1)
        {
            transform.forward = Vector3.Lerp(transform.forward, wantedForward, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.forward = wantedForward;
        }
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public void SetRotationTowards(Vector3 wantedForward)
    {
        this.wantedForward = wantedForward;
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
    public bool GetIsMooving()
    {
        return isMoving;
    }
}
