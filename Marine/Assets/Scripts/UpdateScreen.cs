using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScreen : MonoBehaviour
{
    [SerializeField] RawImage _renderer;
    [SerializeField] GameObject obj;

    public void ReceiveFrameData(Texture2D tex)
    {
        obj.SetActive(false);
        _renderer.texture = tex;
    }
}
