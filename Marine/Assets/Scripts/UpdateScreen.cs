using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScreen : MonoBehaviour
{
    [SerializeField] RawImage _renderer;

    public void ReceiveFrameData(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.CAMERA_FEED)
        {
            RenderTexture renderTexture = (RenderTexture)eventData.CustomData;
            renderTexture.Create();

            _renderer.texture = ToTexture2D(renderTexture);
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += ReceiveFrameData;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveFrameData;
    }

    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new(512, 512, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
