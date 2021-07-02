using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Weapon : Item_Equipment, IEquippable
{
    public WeaponType weaponType;
    public float baseDamageMin = 1;
    public float baseDamageMax = 2;
    public float baseAttackSpeed = 1;
}

public enum WeaponType
{
    Sword1h,
    Sword2h
}