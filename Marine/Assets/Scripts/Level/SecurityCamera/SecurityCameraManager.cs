using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SecurityCameraManager : MonoBehaviour
{
    [SerializeField] List<SecurityCamera> cameras = new List<SecurityCamera>();
    int currentEnabledCamera;

    public void DisableCameraView(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.DISABLE_CAMERA)
        {
            cameras[currentEnabledCamera].CancelInvoke();
            cameras[currentEnabledCamera].enabled = false;
        }
    }

    public void EnableCameraView(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.ENABLE_CAMERA)
        {
            int cameraID = (int)eventData.CustomData;
            cameras[cameraID].enabled = true;
            currentEnabledCamera = cameraID;
        }
    }

    public void SwitchCamera(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.SWITCH_CAMERA)
        {
            int cameraID = (int)eventData.CustomData;

            cameras[currentEnabledCamera].CancelInvoke();
            cameras[currentEnabledCamera].enabled = false;

            cameras[cameraID].enabled = true;
            currentEnabledCamera = cameraID;
        }
    }

    //Network subs
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += DisableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived += EnableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived += SwitchCamera;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= DisableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived -= EnableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived -= SwitchCamera;
    }
}