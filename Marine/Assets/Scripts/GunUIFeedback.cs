using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class GunUIFeedback : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletText;

    public void UpdateCurrentBulletCount(string feedback)
    {
        bulletText.text = feedback;
    }
}