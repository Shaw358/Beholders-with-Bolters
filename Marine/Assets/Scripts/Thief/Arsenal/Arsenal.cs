using ArsenalOfDemocracy.Weapons;
using System.Collections.Generic;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>();
    List<Gadget> gadgets = new List<Gadget>();

    public Weapon GetWeapon(WeaponType type)
    {
        return weapons.Find(x => x.data.weaponType == type);
    }
    
    public Gadget GetGadget()
    {
        return gadgets[0];
    }
}
