using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    bool isAbleToPlay;
    float timer;
    float timerThreshold;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clips;

    public void SetNewThreshold(float newThreshold)
    {
        timerThreshold = newThreshold;
    }

    public void PlayFootStepIfPossible()
    {
        if(isAbleToPlay)
        {
            isAbleToPlay = false;
            
            source.PlayOneShot(clips[Random.Range(0, clips.Length - 1)]);
            timer = 0;
        }
    }

    private void Update()
    {
        if(isAbleToPlay)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer > timerThreshold)
        {
            isAbleToPlay = true;   
        }
    }
}