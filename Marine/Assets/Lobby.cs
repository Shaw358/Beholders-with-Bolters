using System.Collections;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        Debug.Log(PhotonNetwork.CountOfPlayersOnMaster);
        if(PhotonNetwork.CountOfPlayersOnMaster == 2)
        {
            if(isHacker)
            {
                SceneManager.LoadScene("hacker");
            }
            else
            {
                SceneManager.LoadScene("BankLevel");
            }
        }
        else
        {
            ReturnStatus();
        }
    }

    public void ReturnStatus()
    {
        if(PhotonNetwork.CountOfPlayersOnMaster == 2)
        {
            textMeshReturnStatus.text = "Amount of players are incorrect";
        }
    }
}