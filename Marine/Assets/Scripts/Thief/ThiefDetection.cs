using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ThiefDetection : MonoBehaviour
{
    [SerializeField] float secondsTillAlarm;

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
                StartCoroutine(AlarmCountDown());
            }
        }
    }

    [SerializeField] int currentDetectionPoints;
    [SerializeField] private int thresholdTillDetection;

    UnityEvent triggerAlarm;

    public void StopAlarmCountDown()
    {
        StopAllCoroutines();
    }

    private IEnumerator AlarmCountDown()
    {
        yield return new WaitForSeconds(secondsTillAlarm);
        triggerAlarm.Invoke();
    }    
}