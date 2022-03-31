using UnityEngine;
using ArsenalOfDemocracy.Weapons;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Arsenal/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int ammoPerMagazine;
    public int maxAmmo;
    public float fireRate;
    public float recoil;
    public WeaponType weaponType;
}