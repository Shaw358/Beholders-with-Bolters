using System.Collections;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;

public class Lobby : MonoBehaviourPunCallbacks
{
    bool isHacker;
    [SerializeField] TextMeshProUGUI textMeshReturnStatus;

    public void ChangePlayerType(bool type)
    {
        isHacker = type;
    }

    public void LaunchGame()
    {
        PhotonNetwork.RaiseEvent(NetworkingIDs.LOBBY_MENU, isHacker, Photon.Realtime.RaiseEventOptions.Default, SendOptions.SendUnreliable);
        if (isHacker)
        {
            SceneManager.LoadScene("hacker");
        }
        else
        {
            SceneManager.LoadScene("BANKU");
        }
    }

    public void ReceiveLaunchGame(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.LOBBY_MENU)
        {
            Debug.Log("Heh wat jammer");
            textMeshReturnStatus.text = "Call received";
            bool IsHacker = (bool)eventData.CustomData;
            if (!IsHacker)
            {
                SceneManager.LoadScene("hacker");
            }
            else
            {
                SceneManager.LoadScene("BANKU");
            }
        }
    }

    public void ReturnStatus()
    {
        if (PhotonNetwork.CountOfPlayersOnMaster == 2)
        {
            textMeshReturnStatus.text = "Amount of players are incorrect";
        }
    }

    public override void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += ReceiveLaunchGame;
    }

    public override void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveLaunchGame;
    }
}