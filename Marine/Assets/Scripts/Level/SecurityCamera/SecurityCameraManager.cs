using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SecurityCameraManager : MonoBehaviour
{
    #region global vars
    [SerializeField] List<SecurityCamera> cameras = new List<SecurityCamera>();
    int currentEnabledCamera;
    #endregion

    public void DisableCameraView(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.DISABLE_CAMERA)
        {
            cameras[currentEnabledCamera].isActive = false;
        }
    }

    public void EnableCameraView(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.ENABLE_CAMERA)
        {
            int cameraID = (int)eventData.CustomData;
            cameras[cameraID].isActive = true;
            currentEnabledCamera = cameraID;
        }
    }

    public void SwitchCamera(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.SWITCH_CAMERA) //checks if event belongs to this function
        {
            int cameraID = (int)eventData.CustomData; //converts network data 

            //TODO: include some sort of null condition checker for CustomData
            cameras[currentEnabledCamera].isActive = false; //actually switches camera feed
            cameras[cameraID].isActive = true;
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

    //Remove subscribers
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= DisableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived -= EnableCameraView;
        PhotonNetwork.NetworkingClient.EventReceived -= SwitchCamera;
    }
}