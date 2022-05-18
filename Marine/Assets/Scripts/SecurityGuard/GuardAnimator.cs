using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] List<string> animationNames = new List<string>();

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationNames.IndexOf(animationName), 1);
    }

    public float GetAnimationLengthInSeconds()
    {
        return GetAnimationLength.GetLengthOfAnimation(animator);
    }
}