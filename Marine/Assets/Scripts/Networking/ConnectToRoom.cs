using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToRoom : MonoBehaviour
{
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(RoomGeneration.CreateRandomStringID());
    }

    public void JoinRoom(string roomID)
    {
        PhotonNetwork.JoinRoom(roomID);
    }
}