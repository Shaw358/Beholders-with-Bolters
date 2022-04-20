using UnityEngine;

public class GetAnimationLength
{
    /// <summary>
    /// NOTE: Requires a skip frame or wait till end of frame call first
    /// </summary>
    /// <param name="animator">Parameter value to pass.</param>
    /// <returns>Returns a float of the animation clips length in seconds.</returns>
    public static float GetLengthOfAnimation(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}