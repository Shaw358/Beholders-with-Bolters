using UnityEngine;
using Minigames;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    private bool active;
    private void Start()
    {
        gameObject.GetComponent<SymbolMatching>().enabled = false;
        gameObject.GetComponent<Password>().enabled = false;
    }

    public void SymbolMatchingPuzzle(bool validActivation)
    {
        active = validActivation;
        if (active)
        {
            gameObject.GetComponent<SymbolMatching>().enabled = true;
        }
    }

    public void PasswordPuzzle(bool validActivation)
    {
        active = validActivation;
        if (active)
        {
            gameObject.GetComponent<Password>().enabled = true;
        }
    }

}