using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    [SerializeField]private AudioSource source;

    private int averageFrequency;
    private int minFreq;
    private int maxFreq;
    private int timer;
    private string deviceName;
    // Start is called before the first frame update
    void Start()
    {
        //Pick up audio
        deviceName = Microphone.devices[0];
        Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq); //Is alleen een check voor min en max, frequency moet nog assigned worden.
        source = GetComponent<AudioSource>();
        source.loop = false;
        averageFrequency = minFreq + maxFreq / 2;
        if (averageFrequency > minFreq && averageFrequency < maxFreq)
        {
            averageFrequency = minFreq * 2;
        }
        //count duration
        while (Input.GetKeyDown(KeyCode.Mouse0))
        {
            timer = Mathf.RoundToInt(Time.deltaTime * timer);
            source.clip = Microphone.Start(deviceName, false, timer, averageFrequency);
            // --source.Play(); --call Funtion -- ander script voor andere speler
        }
    }

    // Update is called once per frame
    void Update()
    {
        //while walkie-talkie button is being held down timer keeps going else timer stops and saves for duration - reset timer after use

    }
}
