using Photon.Pun;

public class ConnectToPhoton : MonoBehaviourPunCallbacks
{
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

    }
}