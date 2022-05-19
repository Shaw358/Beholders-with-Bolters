using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    int currentCamera;
    RaiseEventOptions raiseEventOptions;

    private void Awake()
    {
        raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            //Insert MP data request code
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCamera--;
            //Insert MP data request code
        }
        PhotonNetwork.RaiseEvent(NetworkingIDs.CAMERA_FEED, currentCamera, raiseEventOptions, SendOptions.SendUnreliable);
    }
}
