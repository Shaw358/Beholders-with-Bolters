using Photon.Pun;
using UnityEngine;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    public bool isPlayer2;

    public void CreateRoom()
    {
        if (!isPlayer2)
        {
            PhotonNetwork.CreateRoom(/*RoomGeneration.CreateRandomStringID()*/"test");
        }
    }

    public void JoinRoom(string roomID)
    {
        if (isPlayer2)
        {
            try
            {
                PhotonNetwork.JoinRoom(/*roomID*/"test");
            }
            catch
            {
                Debug.LogWarning("Room isn't ready yet");
            }
        }
    }
}