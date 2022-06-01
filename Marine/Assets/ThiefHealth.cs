using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefHealth : MonoBehaviour
{
    [Range(0, 1)] public float hp;

    [SerializeField] BarUpdater healthBar;

    private void Awake()
    {
        healthBar.SetMaxVal(1);
    }

    public void DecreaseHealth(float amount)
    {
        hp -= amount;
        healthBar.UpdateHealthBar(hp);
        if(hp <= 0)
        {
            //Death Stuff;
        }
    }
}