using System;
using UnityEngine;

public class CameraFeed : MonoBehaviour
{
    [SerializeField] RenderTexture cam;

    public RenderTexture ReadImageFromCamera()
    {
        return cam;
    }

    /// <summary>
    /// Deprecated
    /// </summary>
    /// <returns>Returns byte array of a Texture2D</returns>
    public byte[] GetImageFromCameraAsObject()
    {
        byte[] bArray = toTexture2D(cam).GetRawTextureData();

        return bArray;
    }

    public Texture2D GetImageFromCameraAsTexture2D()
    {
        return toTexture2D(cam);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(512 / 2, 512 / 2, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}