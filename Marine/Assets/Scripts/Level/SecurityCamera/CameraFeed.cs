using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFeed : MonoBehaviour
{
    [SerializeField] Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    public RenderTexture ReadImageFromCamera()
    {
        return cam.targetTexture;
    }

    public object GetImageFromCameraAsObject()
    {
        object frame = cam.targetTexture;
        return frame;
    }
}