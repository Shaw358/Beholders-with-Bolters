using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{
    [SerializeField]private RenderTexture rt;
    [SerializeField]private Camera[] cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cam.Length; i++)
        {
            //cam[i];
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                cam[i + 1].targetTexture = rt;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                cam[i - 1].targetTexture = rt;
            }
            else
            {
                cam[i].targetTexture = rt;
            }
        }
    }
}
