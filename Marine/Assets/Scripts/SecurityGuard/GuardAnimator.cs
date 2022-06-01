using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] List<string> animationNames = new List<string>();
    bool isOverridePriority;

    public void PlayAnimation(string animationName, bool isOverride)
    {
        if(isOverride)
        {
            isOverridePriority = isOverride;
        }
        if(!isOverride && isOverridePriority)
        {
            return;
        }
        animator.Play(animationNames.IndexOf(animationName), 1);
    }

    public float GetAnimationLengthInSeconds()
    {
        return GetAnimationLength.GetLengthOfAnimation(animator);
    }
}