using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThiefAnimation;

public class ThiefAnimatonHandler : MonoSingleton<ThiefAnimatonHandler>
{
    [SerializeField] Animator animator;
    [SerializeField] Animator gunAnimator;
    [SerializeField] List<string> animationNames = new List<string>();

    public void PlayAnimation(ThiefAnimations animation)
    {
        animator.Play(animationNames[(int)animation]);
        gunAnimator.Play(animationNames[(int)animation]);
    }
}