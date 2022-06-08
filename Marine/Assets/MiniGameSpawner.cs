using ExitGames.Client.Photon;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSpawner : MonoSingleton<MiniGameSpawner>
{
    [SerializeField] List<SymbolMatchingMinigame> symbolMinigames = new List<SymbolMatchingMinigame>();
    [SerializeField] List<PasswordMinigame> passwordMinigames = new List<PasswordMinigame>();
    [SerializeField] SymbolMatching matching;

    public void SpawnSymbolMatchingMinigame(EventData eventData)
    {
        if (eventData.Code == NetworkingIDs.MINIGAMESPAWNER)
        {
            matching.InitMinigame(symbolMinigames[0]);
            symbolMinigames.RemoveAt(0);
        }
    }

    public SymbolMatchingMinigame GetSymbolMatchingMinigameInfo()
    {
        return symbolMinigames[0];
    }

    public void SpawnPasswordMinigame()
    {

    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += SpawnSymbolMatchingMinigame;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= SpawnSymbolMatchingMinigame;
    }
}