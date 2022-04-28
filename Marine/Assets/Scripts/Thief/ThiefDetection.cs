using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ThiefDetection : MonoBehaviour
{
    [SerializeField] float secondsTillAlarm;

    public void StopAlarmCountDown()
    {
        StopAllCoroutines();
    }

    private IEnumerator AlarmCountDown()
    {
        yield return new WaitForSeconds(secondsTillAlarm);
        
    }    
}