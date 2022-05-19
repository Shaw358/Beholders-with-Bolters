using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    public RoomIDGeneration generation = new RoomIDGeneration();
    [SerializeField] UnityEvent action;
    [SerializeField] TMP_InputField field;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(field.text);
    }

    public void CreateRoom()
    {
        generation.CreateRandomStringID();
        PhotonNetwork.CreateRoom(generation.ID);
    }

    public override void OnJoinedRoom()
    {
        action.Invoke();
    }
}