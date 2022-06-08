using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialiser : MonoBehaviour
{
    [SerializeField] Camera thiefCamera;
    [SerializeField] Camera hackerCamera;
    [SerializeField] GameObject ThiefUI;

    private void Awake()
    {
        InitGame();
    }

    public void InitGame()
    {
        if (MultiplayerDataTracker.instance.player == MultiplayerDataTracker.PlayerType.Hacker)
        {
            hackerCamera.enabled = true;
            thiefCamera.enabled = false;
            ThiefUI.SetActive(false);
        }
        else
        {
            hackerCamera.enabled = false;
            thiefCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        Destroy(gameObject);
    }
}
