using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Pun;

public class SymbolMatching : MonoBehaviour
{
    bool canGuess;
    [SerializeField] TextMeshProUGUI coolDownText; 
    SymbolMatchingMinigame gameStats;
    [SerializeField] Image[] symbols;

    public void InitMinigame(SymbolMatchingMinigame newGameStats)
    {
        gameObject.SetActive(true);
        gameStats = newGameStats;
        for (int index = 0; index < symbols.Length; index++)
        {
            symbols[index].sprite = gameStats.possibleSymbols[index];
        }
        canGuess = true;
    }

    public void OnImageClick(int index)
    {
        Debug.Log("It hurt so much");
        if(!canGuess)
        {
            return;
        }
        if(index != gameStats.currentIndexOfSymbol)
        {
            StartCoroutine(CoolDown());
        }
        else
        {
            PhotonNetwork.RaiseEvent(NetworkingIDs.MINIGAME, null, Photon.Realtime.RaiseEventOptions.Default, SendOptions.SendUnreliable);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator CoolDown()
    {
        canGuess = false;
        float cooldown = gameStats.guessCooldown;

        while (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            coolDownText.text = "Incorrect Symbol! Rebooting in: " + Mathf.Round(cooldown).ToString();
            yield return null;
        }
        coolDownText.text = "Rebooted!";
        canGuess = true;
    }
}
