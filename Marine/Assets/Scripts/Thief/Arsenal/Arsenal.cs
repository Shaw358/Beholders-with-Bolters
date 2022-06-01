using ArsenalOfDemocracy.Weapons;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class Arsenal : MonoBehaviour
{
    [SerializeField] GunUIFeedback feedback;
    [SerializeField] List<WeaponData> weaponData = new List<WeaponData>();
    [SerializeField] List<Weapon> weapons = new List<Weapon>();

    [SerializeField] int currentWeapon;

    public void UseCurrentWeapon()
    {
        weaponData[currentWeapon].currentAmmo--;
        weaponData[currentWeapon].maxAmmo--;
        weapons[currentWeapon].Attack();

        if(weaponData[currentWeapon].currentAmmo == 0)
        {
            Reload();
        }

        UpdateFeedback();
    }

    public void Reload()
    {
        //weapons[currentWeapon].Attack();
        weapons[currentWeapon].PlayReloadSFX();
        StartCoroutine(ReloadNumerator());
    }

    public WeaponData GetCurrentWeaponData()
    {
        return weaponData[currentWeapon];
    }

    private IEnumerator ReloadNumerator()
    {
        //NOTE: This is bad, hardcoding this is a horrible idea but time has forced my hand
        yield return new WaitForSeconds(2);
        weaponData[currentWeapon].currentAmmo = weaponData[currentWeapon].ammoPerMagazine;
        UpdateFeedback();
        Debug.Log("RELOAD");
    }

    private void UpdateFeedback()
    {
        string newFeedback = weaponData[currentWeapon].currentAmmo.ToString() + "/" + weaponData[currentWeapon].ammoPerMagazine.ToString();
        feedback.UpdateCurrentBulletCount(newFeedback);
    }
}
