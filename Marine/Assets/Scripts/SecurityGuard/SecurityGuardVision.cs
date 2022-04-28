using UnityEngine;
using UnityEngine.Events;

public class SecurityGuardVision : MonoBehaviour
{
    [SerializeField] float viewRadius;
    [SerializeField] float viewAngle;

    //TODO: Implement invisible cone of view for guard
    [SerializeField] LayerMask playerDetectionPointLayer;
    LayerMask _else;

    [SerializeField] int currentDetectionPoints;
    int CurrentDetectionPoints
    {
        get
        {
            return currentDetectionPoints;
        }
        set
        {
            currentDetectionPoints = value;
            if (currentDetectionPoints >= thresholdTillDetection)
            {
                triggerAlarm.Invoke();
            }
        }
    }

    [SerializeField] private int thresholdTillDetection;
    UnityEvent triggerAlarm;

    private void Awake()
    {
        _else = ~LayerMask.GetMask("PlayerDetectionPoint");
        _else -= LayerMask.GetMask("Guard");
    }

    private void Update()
    {
        PlayerDetection();
    }

    //The eyes of the guard, throws a spehre (but at an angle) to check if any of the detection points are in it.
    //A raycast is done to check if there are obstacles between the detection point and the guard
    public void PlayerDetection()
    {
        currentDetectionPoints = 0;
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerDetectionPointLayer);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {            
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //TODO: Too many nested if statements to my liking, consider making it shorter?
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, _else))
                {
                    currentDetectionPoints += targetsInViewRadius[i].GetComponent<DetectionPoint>().detectionPointValue;
                }
            }
        }
    }
}