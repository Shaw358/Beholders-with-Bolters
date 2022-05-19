using Photon.Pun;
using TMPro;
using UnityEngine;

public class ConnectToPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI cofirmText;

    private void Start()
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
        cofirmText.text = "Server status: OK";
    }
}