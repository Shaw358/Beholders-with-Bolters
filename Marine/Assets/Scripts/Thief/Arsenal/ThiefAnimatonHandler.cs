using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAnimatonHandler : MonoSingleton<ThiefAnimatonHandler>
{
    [SerializeField] Animator animator;
    [SerializeField] List<string> animationNames = new List<string>();

    public void PlayAnimation()
    {

    }
}