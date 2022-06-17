using System.Collections;
using UnityEngine;
using Guard;

[RequireComponent(typeof(SecurityGuard))]
public class GuardMovement : MonoBehaviour
{
    [SerializeField] GuardAnimator gAnimator;
    [SerializeField] Transform currentWaypoint;
    [SerializeField] Route currentRoute;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] int restChance; //Chance of the guard taking a small break after going to a waypoint
    [SerializeField] float partolRotationSpeed;
    [SerializeField] float responding;

    [SerializeField] float preferredDistanceInMeters = 5;

    [SerializeField] bool canMove;
    [SerializeField] bool canWalk;

    [SerializeField] Rigidbody rb;
    [SerializeField] public GuardState currentState;

    public bool CanWalk
    {
        get
        {
            return canWalk;
        }
    }

    private void Awake()
    {
        if (currentWaypoint)
        {
            StartCoroutine(RotatedTowards(currentWaypoint.position));
        }
        currentWaypoint = currentRoute.GetWaypoint(0);
    }

    private void Update()
    {
        if (!canMove /*|| MultiplayerDataTracker.instance.player == MultiplayerDataTracker.PlayerType.Hacker*/)
        {
            return;
        }

        if (canWalk)
        {
            switch (currentState)
            {
                case GuardState.Patrolling:
                    MoveForward(walkSpeed);
                    gAnimator.PlayAnimation("guardWalk", false);
                    //Checkpoint
                    if (Vector3.Distance(transform.position, currentWaypoint.position) < .35f)
                    {
                        currentWaypoint = currentRoute.GetNextWaypoint(currentWaypoint);
                        StartCoroutine(RotatedTowards(currentWaypoint.position));
                    }
                    break;
                case GuardState.Alerted:
                    MoveForward(0);
                    break;
                case GuardState.Responding:
                    Debug.Log(Vector3.Distance(currentWaypoint.position, ThiefController.instance.transform.position));
                    if (Vector3.Distance(currentWaypoint.position, ThiefController.instance.transform.position) > 3.5f && Vector3.Distance(currentWaypoint.position, ThiefController.instance.transform.position) < 7.5f)
                    {
                        //Shooting happens here
                        MoveForward(0);
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, currentWaypoint.position) < .35f)
                        {
                            currentRoute.FindBestPathToWaypoint(currentWaypoint, currentRoute.FindNearestWaypointToGameobject(ThiefController.instance.gameObject, preferredDistanceInMeters));
                            currentWaypoint = currentRoute.GetNextWaypoint(currentWaypoint);
                            StartCoroutine(RotatedTowards(currentWaypoint.position));
                        }
                        MoveForward(runSpeed);
                        gAnimator.PlayAnimation("guardRun", false);
                    }
                    break;
            }
        }
    }

    public IEnumerator RotatedTowards(Vector3 lookAtPoint)
    {
        Vector3 flatDirPath = Vector3.Scale((lookAtPoint - transform.position), new Vector3(1, 0, 1));
        Quaternion targetRotation = Quaternion.LookRotation(flatDirPath, Vector3.up);

        float angle = Quaternion.Angle(transform.rotation, targetRotation);
        float threshold = .5f;

        float rotationSpeed = currentState == GuardState.Patrolling ? partolRotationSpeed : responding;

        //Decides forward movement
        if (Mathf.Abs(angle) > 15)
        {
            canWalk = false;
        }
        else
        {
            rotationSpeed *= .4f;
        }

        //Rotation of obj
        while (angle > threshold)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
            angle = Quaternion.Angle(transform.rotation, targetRotation);
            yield return null;
        }
        canWalk = true;
    }

    private void MoveForward(float speed)
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}