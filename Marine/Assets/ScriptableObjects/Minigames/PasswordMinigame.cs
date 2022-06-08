using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Password", menuName = "Minigames/Password", order = 2)]
public class PasswordMinigame : ScriptableObject
{
    public string correctPassword;
    public float cooldown;
}
