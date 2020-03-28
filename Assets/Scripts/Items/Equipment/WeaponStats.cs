using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponStats {
    
    public enum WeaponType
    {
        Sword1h,
        Sword2h
    }

    public WeaponType weaponType;
    public float activeFramesStart;
    public float activeFramesEnd;
    public float baseDamageMin = 0;
    public float baseDamageMax = 0;
    public float baseAttackSpeed = 1;

    public void SetActiveFrames()
    {
        if(weaponType == WeaponType.Sword1h)
        {
            activeFramesStart = 30f / 120f;
            activeFramesEnd = 70f / 120f;
        }
        else if (weaponType == WeaponType.Sword2h)
        {
            activeFramesStart = 30f / 120f;
            activeFramesEnd = 70f / 120f;
        }
    }
}