using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}