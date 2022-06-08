using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SecurityCameraManager : MonoBehaviour
{
    #region global vars
    [SerializeField] List<SecurityCamera> cameras = new List<SecurityCamera>();
    [SerializeField] UpdateScreen updateScreen;
    int currentEnabledCamera;
    #endregion

    /*public void DisableCameraView(EventData eventData)
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
    }*/
    private void Update()
    {
        updateScreen.ReceiveFrameData(cameras[currentEnabledCamera].cameraFeed.GetImageFromCameraAsTexture2D());
        CheckInput();
    }

    void CheckInput()
    {
        if (MultiplayerDataTracker.instance.player == MultiplayerDataTracker.PlayerType.Hacker)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentEnabledCamera < cameras.Count - 1)
            {
                currentEnabledCamera++;
                NextCamera();
                //Insert MP data request code
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentEnabledCamera > 0)
            {
                currentEnabledCamera--;
                Previous();
                //Insert MP data request code
            }
        }
    }

    public void NextCamera()
    {
        cameras[currentEnabledCamera - 1].DeactivateCamera(); //actually switches camera feed
        cameras[currentEnabledCamera].ActivateCamera();
    }

    public void Previous()
    {
        cameras[currentEnabledCamera + 1].DeactivateCamera(); //actually switches camera feed
        cameras[currentEnabledCamera].ActivateCamera();
    }

    //Network subs
    /*private void OnEnable()
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
    }*/
}