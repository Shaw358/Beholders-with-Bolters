using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFeed : MonoBehaviour
{
    [SerializeField] RenderTexture cam;

    public RenderTexture ReadImageFromCamera()
    {
        return cam;
    }

    public object GetImageFromCameraAsObject()
    {
        object frame = cam;
        return frame;
    }
}