using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BarUpdater : MonoBehaviour
{
    public Image barFiller;

    [SerializeField] private float maxVal;

    public void UpdateHealthBar(float newVal)
    {
        barFiller.fillAmount = Mathf.Clamp((float)newVal / maxVal, 0, 1f);
    }

    public void SetMaxVal(float newMaxVal)
    {
        maxVal = newMaxVal;
    }
}