using System.Collections;
using UnityEngine;
using Guard;

[RequireComponent(typeof(SecurityGuard))]
public class GuardMovement : MonoBehaviour
{
    [SerializeField] Transform currentWaypoint;
    [SerializeField] Route currentRoute;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] int restChance; //Chance of the guard taking a small break after going to a waypoint
    [SerializeField] float partolRotationSpeed;
    [SerializeField] float altertedRotationSpeed;

    [SerializeField] bool canMove;
    [SerializeField] bool canWalk;

    [SerializeField] Rigidbody rb;
    [SerializeField] GuardState currentState;

    private void Start()
    {
        StartCoroutine(RotatedTowards(currentWaypoint.position));
    }

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        //TODO: Move guard
        if (canWalk)
        {
            switch (currentState)
            {
                case GuardState.Patrolling:
                    MoveForward(walkSpeed);
                    break;
                case GuardState.Alerted:
                    MoveForward(runSpeed);
                    break;
            }
        }

        //Checkpoint
        if (Vector3.Distance(transform.position, currentWaypoint.position) < .15f)
        {
            currentWaypoint = currentRoute.GetNextWaypoint(currentWaypoint);
            StartCoroutine(RotatedTowards(currentWaypoint.position));
        }
    }

    public IEnumerator RotatedTowards(Vector3 lookAtPoint)
    {
        Vector3 flatDirPath = Vector3.Scale((lookAtPoint - transform.position), new Vector3(1, 0, 1));
        Quaternion targetRotation = Quaternion.LookRotation(flatDirPath, Vector3.up);

        float angle = Quaternion.Angle(transform.rotation, targetRotation);
        float threshold = .5f;

        float rotationSpeed = currentState == GuardState.Patrolling ? partolRotationSpeed : altertedRotationSpeed;

        //Decides forward movement
        if (Mathf.Abs(angle) > 15)
        {
            canWalk = false;
        }

        //Rotation of obj
        while (angle > threshold)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
            angle = Quaternion.Angle(transform.rotation, targetRotation);
            yield return null;
        }
        Debug.Log("why");
        canWalk = true;
    }

    private void MoveForward(float speed)
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}