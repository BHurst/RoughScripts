using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier {

    public StatModifiers Mod;
    public float ModAmount;

    public enum StatModifiers
    {
        #region Form mods
        Arc_Damage_Flat,
        Arc_Damage_Add,
        Arc_Damage_Multiply,
        Aura_Damage_Flat,
        Aura_Damage_Add,
        Aura_Damage_Multiply,
        Beam_Damage_Flat,
        Beam_Damage_Add,
        Beam_Damage_Multiply,
        Lance_Damage_Flat,
        Lance_Damage_Add,
        Lance_Damage_Multiply,
        Nova_Damage_Flat,
        Nova_Damage_Add,
        Nova_Damage_Multiply,
        Orb_Damage_Flat,
        Orb_Damage_Add,
        Orb_Damage_Multiply,
        Point_Damage_Flat,
        Point_Damage_Add,
        Point_Damage_Multiply,
        SelfCast_Damage_Flat,
        SelfCast_Damage_Add,
        SelfCast_Damage_Multiply,
        Strike_Damage_Flat,
        Strike_Damage_Add,
        Strike_Damage_Multiply,
        Wave_Damage_Flat,
        Wave_Damage_Add,
        Wave_Damage_Multiply,
        Weapon_Damage_Flat,
        Weapon_Damage_Add,
        Weapon_Damage_Multiply,
        Zone_Damage_Flat,
        Zone_Damage_Add,
        Zone_Damage_Multiply,
        #endregion
        #region Element mods
        Air_Damage_Flat,
        Air_Damage_Add,
        Air_Damage_Multiply,
        Arcane_Damage_Flat,
        Arcane_Damage_Add,
        Arcane_Damage_Multiply,
        Astral_Damage_Flat,
        Astral_Damage_Add,
        Astral_Damage_Multiply,
        Ethereal_Damage_Flat,
        Ethereal_Damage_Add,
        Ethereal_Damage_Multiply,
        Fire_Damage_Flat,
        Fire_Damage_Add,
        Fire_Damage_Multiply,
        Kinetic_Damage_Flat,
        Kinetic_Damage_Add,
        Kinetic_Damage_Multiply,
        Nature_Damage_Flat,
        Nature_Damage_Add,
        Nature_Damage_Multiply,
        Water_Damage_Flat,
        Water_Damage_Add,
        Water_Damage_Multiply,
        #endregion
        Global_Damage_Add,
        Global_Damage_Multiply,
        MoveSpeed_Add
    }
}