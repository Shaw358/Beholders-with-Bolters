using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Symbol", menuName = "Minigames/Symbol", order = 1)]
public class SymbolMatchingMinigame : ScriptableObject
{
    public float guessCooldown;
    public Sprite[] possibleSymbols;
    public Sprite correctSymbol;
    public int currentIndexOfSymbol;
}