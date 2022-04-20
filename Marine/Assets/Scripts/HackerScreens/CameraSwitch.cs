using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    // Start is called before the first frame update
    
    void Start()
    {
        //Get the textured uploaded to channel and add it to camera
        ///camera = rendertexture
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            //Insert MP data request code
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //Insert MP data request code
        }
    }
}
