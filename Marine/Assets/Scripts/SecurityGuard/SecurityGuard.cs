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

    private void Update()
    {
        switch (currentState)
        {
            case GuardState.Patrolling:
                break;
            case GuardState.Alerted:
                break;
            case GuardState.Responding:
                break;
        }
    }

    public void DecreaseHealth(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //TODO: Death anim
        }
    }
}