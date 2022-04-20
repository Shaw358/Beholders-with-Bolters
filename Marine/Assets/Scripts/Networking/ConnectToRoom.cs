using Photon.Pun;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    public bool isPlayer2;

    void Start()
    {
        ConnectToPhotonNetwork();
    }

    public void ConnectToPhotonNetwork()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        if (!isPlayer2)
        {
            CreateRoom();
            return;
        }
        PhotonNetwork.JoinRoom(/*roomID*/"test");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(/*RoomGeneration.CreateRandomStringID()*/ "test");
    }

    public override void OnJoinedRoom()
    {
        if (!isPlayer2)
        {
            SceneManager.LoadScene("FpsBuildingScene");
        }
        else
        {
            SceneManager.LoadScene("hacker");
        }
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