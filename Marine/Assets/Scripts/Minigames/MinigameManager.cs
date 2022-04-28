using UnityEngine;
using Minigames;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> passwordMinigames = new List<GameObject>();
    [SerializeField] List<GameObject> symbolMinigames = new List<GameObject>();
    [SerializeField] List<GameObject> keyMinigames = new List<GameObject>();
    [SerializeField] List<GameObject> connnectDotsMinigames = new List<GameObject>();

    public GameObject GetRandomMiniGame(MinigameType type)
    {
        switch (type)
        {
            case MinigameType.Passwords:
                int randomPasswordGame = Random.Range(0, passwordMinigames.Count);
                GameObject minigame = passwordMinigames[randomPasswordGame];
                passwordMinigames.RemoveAt(randomPasswordGame);
                return minigame;
            case MinigameType.Symbol:
                int randomSymbolGame = Random.Range(0, symbolMinigames.Count);
                GameObject passwordMinigame = symbolMinigames[randomSymbolGame];
                symbolMinigames.RemoveAt(randomSymbolGame);
                return passwordMinigame;
            case MinigameType.Key:
                int randomKeyGame = Random.Range(0, keyMinigames.Count);
                GameObject keyMinigame = keyMinigames[randomKeyGame];
                keyMinigames.RemoveAt(randomKeyGame);
                return keyMinigame;
            case MinigameType.ConnectsDots:
                int randomConnectDotsGame = Random.Range(0, connnectDotsMinigames.Count);
                GameObject connectsDotsminigame = connnectDotsMinigames[randomConnectDotsGame];
                connnectDotsMinigames.RemoveAt(randomConnectDotsGame);
                return connectsDotsminigame;
        }
        return null;
    }
}