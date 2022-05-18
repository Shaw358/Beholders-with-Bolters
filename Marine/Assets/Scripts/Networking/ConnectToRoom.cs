using Photon.Pun;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    RoomIDGeneration generation;

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRoom(/*roomID*/"test");
    }

    public void CreateRoom()
    {
        generation.CreateRandomStringID();
        PhotonNetwork.CreateRoom(generation.ID);
    }

    public override void OnJoinedRoom()
    {

    }

    public void ChangeScene()
    {
        try
        {
            SceneManager.LoadScene("hacker");
        }
        catch
        {
            Debug.LogWarning("Room isn't ready yet");
        }
    }
}