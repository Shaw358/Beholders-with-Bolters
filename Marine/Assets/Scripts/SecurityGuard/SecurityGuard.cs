using System.Collections;
using UnityEngine;
using Guard;

public class SecurityGuard : MonoBehaviour
{
    int hp;
    GuardState currentState;

    [SerializeField] GuardMovement gMovement;
    [SerializeField] SecurityGuardVision gVision;
    [SerializeField] GuardAnimator gAnimator;

    private void Awake()
    {
        currentState = GuardState.Patrolling;
    }

    public void DecreaseHealth(int damage)
    {
        hp -= damage;
        if(currentState != GuardState.Alerted || currentState != GuardState.Responding)
        {
            PlayAlarmAnimation();
        }
        if (hp <= 0)
        {
            StopAllCoroutines();
            gAnimator.PlayAnimation("DeadMF", true);
        }
    }

    private IEnumerator EnablePickupable()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(gAnimator.GetAnimationLengthInSeconds());
        GetComponent<PickUpable>().TurnOnCanInteract();
    }

    public void PlayAlarmAnimation()
    {
        currentState = GuardState.Alerted;
        gAnimator.PlayAnimation("GuardAlert", true);
        StartCoroutine(SwitchToAlarmBehaviourAfterAnimation());
    }

    public IEnumerator SwitchToAlarmBehaviourAfterAnimation()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(gAnimator.GetAnimationLengthInSeconds());
        GameObject.Find("Alarms").GetComponent<SetObjectActives>().ActivateObjects();
        currentState = GuardState.Responding;
    }

    private void Update()
    {
        gMovement.currentState = currentState;
    }
}