using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerDataTracker : MonoSingleton<MultiplayerDataTracker>
{
    public enum PlayerType
    {
        Hacker,
        Thief
    }

    public PlayerType player;

    public void SetPlayerType(int newPlayerType)
    {
        player = (PlayerType)newPlayerType;
    }
}
