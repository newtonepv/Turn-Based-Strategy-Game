using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    bool isMoving;
    Vector3 wantedForward;
    Vector3 destination;
    Unit unit;

    [SerializeField] float rotateSpeed;
    [SerializeField] float mooveSpeed;
    [SerializeField] float maxDistanceFromDestination;
    [SerializeField] int maxMoveDistance;

    PlayerAnimatorScript playerAnimator;
    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimatorScript>();
        wantedForward = transform.forward;
        destination = transform.position;
    }

    void Start()
    {
        TryGetComponent<Unit>(out unit);
        if (unit)
        {
            unit.SetPosInGrid(transform.position);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if(unit)
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
    public List<GridPos> GetActualActionValidGridPosList()
    {
        List<GridPos> list = new List<GridPos>();

        GridPos gridPos;

        gridPos = unit.GetGridPos();

        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int y = -maxMoveDistance; y <= maxMoveDistance; y++) {
                GridPos offsetGridPos = new GridPos(x, y);

                GridPos testGridPos = offsetGridPos + gridPos;

                if (GridCreator.Instance.HasUnitOnGridPos(testGridPos) && !(gridPos==testGridPos) )
                {
                    list.Add(testGridPos);

                    Debug.Log((testGridPos).ToString());
                }

            }
        }
        return list;

    } 
}
