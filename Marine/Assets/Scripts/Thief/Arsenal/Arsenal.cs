using ArsenalOfDemocracy.Weapons;
using ArsenalOfDemocracy.Gadgets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    [SerializeField] List<WeaponData> weaponData = new List<WeaponData>();
    [SerializeField] List<Weapon> weapons = new List<Weapon>();
    [SerializeField] List<Gadget> gadgets = new List<Gadget>();

    int currentWeapon;

    public void UseCurrentWeapon()
    {
        weapons[currentWeapon].Attack();
    }

    //FIXME: Stange issue regarding lambda??????
    /*public Weapon GetWeapon(WeaponType type)
    {
        return weaponData.Find(x => x.weaponType == type);
    }*/

    public bool CheckIfGadgetExists(GadgetType newType)
    {
        return gadgets.Any(gadget => gadget.gadgetType == newType);
    }

    public Gadget GetGadget(GadgetType newType)
    {
        return gadgets.Find(x => x.gadgetType == newType);
    }

    public Weapon GetCurrentWeapon()
    {
        return weapons[currentWeapon];
    }

    public WeaponData GetCUrrentWeaponData()
    {
        return weaponData[currentWeapon];
    }
}
