using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScreen : MonoBehaviourPunCallbacks
{
    [SerializeField] RawImage _renderer;

    public void ReceiveFrameData(EventData eventData)
    {
        Debug.Log(eventData.Code);
        if (eventData.Code == NetworkingIDs.CAMERA_FEED)
        {
            Texture2D tex = new Texture2D(250, 250, TextureFormat.RGBA32, false);

            tex.LoadRawTextureData((byte[])eventData.CustomData);
            tex.Apply();

            //RenderTexture renderTexture = (RenderTexture)eventData.CustomData;
            //renderTexture.Create();

            _renderer.texture = tex;//ToTexture2D(renderTexture);
        }
    }

    public override void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveFrameData;
    }

    public override void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += ReceiveFrameData;
    }
}
