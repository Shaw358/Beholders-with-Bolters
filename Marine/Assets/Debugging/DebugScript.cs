using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using System.Collections;

public class DebugScript : MonoBehaviour
{
    public ConnectToPhoton photon;
    public ConnectToRoom room;

    public TextMeshProUGUI pro;

    int val;

    void Start()
    {
        photon.ConnectToPhotonNetwork();
        StartCoroutine(numerator());
    }

    private IEnumerator numerator()
    {
        yield return new WaitForSeconds(5);
        room.CreateRoom();
        yield return new WaitForSeconds(5);
        room.JoinRoom("");
    }
    
    public void SendData()
    {
        PhotonNetwork.RaiseEvent(NetworkingIDs.DEBUGGING, val,Photon.Realtime.RaiseEventOptions.Default, SendOptions.SendUnreliable);
        val++;
        pro.text = val.ToString();
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += ReceiveData;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveData;
    }

    public void ReceiveData(EventData eventData)
    {
        Debug.Log("ass00");
        if (eventData.Code == NetworkingIDs.DEBUGGING)
        {
            val++;
            pro.text = val.ToString();
        }
    }
}
