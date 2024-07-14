using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    bool isMoving;
    Vector3 wantedForward;
    Vector3 destination;

    [SerializeField] float rotateSpeed;
    [SerializeField] float mooveSpeed;
    [SerializeField] float maxDistanceFromDestination;
    [SerializeField] int maxMoveDistance;

    PlayerAnimatorScript playerAnimator;

     protected override void Awake()
    {
        base.Awake();
        playerAnimator = GetComponent<PlayerAnimatorScript>();
        wantedForward = transform.forward;
        destination = transform.position;
    }

    void Start()
    {
        unit.SetPosInGrid(transform.position);
    }

    void Update()
    {
        if (!isActive) { return; }
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        unit.ClearPosInGrid(transform.position);
        ChangePos();
        unit.SetPosInGrid(transform.position);
    }
    private void ChangePos()
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
            isActive = false;
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
    public void Move(Vector3 destination)
    {
        isActive = true;
        SetDestination(destination);
        SetRotationTowards(destination);
    }
    public void SetDestination(Vector3 destination)
    {
        if (IsValidGridPos(GridCreator.Instance.WorldToGrid(destination)))
        {
            this.destination = destination;
        }
    }

    public void SetRotationTowards(Vector3 wantedPos)
    {

        wantedForward = wantedPos - transform.position;
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

                if (GridCreator.Instance.GridPositionExist(testGridPos) && !GridCreator.Instance.HasUnitOnGridPos(testGridPos) && !(gridPos==testGridPos) )
                {
                    list.Add(testGridPos);

                }

            }
        }
        return list;

    } 
    public bool IsValidGridPos(GridPos gridPos)
    {
        return GetActualActionValidGridPosList().Contains(gridPos);
    }
}
