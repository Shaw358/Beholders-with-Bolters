using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;

    [SerializeField] Light light;

    private void Update()
    {
        light.intensity = Random.Range(minIntensity, maxIntensity);    
    }
}