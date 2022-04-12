using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private RenderTexture render;
    private int currentCamera;
    // Start is called before the first frame update
    
    void Start()
    {
        //Get the textured uploaded to channel and add it to camera
        currentCamera = 1; //replace 1 with actual camera index 0,1,2 or 3
        cam.targetTexture = render;
    }
    public void CameraSwitchRight()
    {
        currentCamera++;
        AdaptCamera();
    }
    public void CameraSwitchLeft()
    {
        currentCamera--;
        AdaptCamera();
    }
    void AdaptCamera()
    {
        cam.targetDisplay = currentCamera;
        cam.targetTexture = render;
    }
    void RecieveCameraData()
    {

    }
    void RequestCameraData()
    {

    }
}
