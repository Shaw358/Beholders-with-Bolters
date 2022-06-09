using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigameTrigger : InteractableBase
{
    [Header("On succesful minigame completion")]
    [SerializeField] UnityEvent onSuccesfulMinigame;
    [SerializeField] Image symbolImage;
    bool isActive = false;

    private void Start()
    {
        canShowInteractButton = true;
        Interact();
    }

    public override void Interact()
    {
        isActive = true;
        canShowInteractButton = false;

        symbolImage.enabled = true;

        symbolImage.sprite = MiniGameSpawner.instance.GetSymbolMatchingMinigameInfo().correctSymbol;
        PhotonNetwork.RaiseEvent(NetworkingIDs.MINIGAMESPAWNER, null, Photon.Realtime.RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }

    public void SuccesfulMinigame(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.MINIGAME && isActive)
        {
            onSuccesfulMinigame?.Invoke();
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += SuccesfulMinigame;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= SuccesfulMinigame;
    }
}