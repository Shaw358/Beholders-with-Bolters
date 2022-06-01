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

    public void DecreaseHealth(int damage)
    {
        Debug.Log("wOW");
        hp -= damage;
        if(currentState != GuardState.Alerted || currentState != GuardState.Responding)
        {
            SwitchToAlarmBehaviourAfterAnimation();
        }
        if (hp <= 0)
        {
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
        gAnimator.PlayAnimation("Alarmed", true);
    }

    public IEnumerator SwitchToAlarmBehaviourAfterAnimation()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(gAnimator.GetAnimationLengthInSeconds());
        currentState = GuardState.Responding;
    }

    private void Update()
    {
        gMovement.currentState = currentState;
    }
}