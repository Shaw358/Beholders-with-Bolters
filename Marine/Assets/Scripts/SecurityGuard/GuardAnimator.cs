using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool isOverridePriority;

    public void PlayAnimation(string animationName, bool isOverride)
    {
        if (isOverride)
        {
            isOverridePriority = isOverride;
            StartCoroutine(RemoveOverridePriority());
        }
        if (!isOverride && isOverridePriority)
        {
            return;
        }
        animator.Play(animationName, 0);
    }

    public float GetAnimationLengthInSeconds()
    {
        return GetAnimationLength.GetLengthOfAnimation(animator);
    }

    private IEnumerator RemoveOverridePriority()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(GetAnimationLengthInSeconds());
        isOverridePriority = false;
    }
}