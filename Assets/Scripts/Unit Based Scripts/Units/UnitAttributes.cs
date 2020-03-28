using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttributes {
    public int Strength = 0;//Physical crit damage, Melee/Ranged DRAWN WEAPON damage,
    public int Agility = 0;//Movement speed, Attack speed, Physical crit chance
    public int Intellect = 0;//Mana pool recovery/maximum, Spell damage, Spell crit
    public int Wisdom = 0;//Spell cast speed, Lore
    public int Stamina = 0;//Defence increase
    public int Willpower = 0;//Resistance increase, Spell crit damage
    public int Skill = 0;//Chance to apply status increased, Total crit chance, Cooldown reduction

    public void ModifyAttribute(string attribute, int mod)
    {
        switch (attribute)
        {
            case "Strength":
                Strength += mod;
                break;
            case "Agility":
                Agility += mod;
                break;
            case "Intellect":
                Intellect += mod;
                break;
            case "Wisdom":
                Wisdom += mod;
                break;
            case "Stamina":
                Stamina += mod;
                break;
            case "Willpower":
                Willpower += mod;
                break;
            case "Skill":
                Skill += mod;
                break;
            default:
                break;
        }
    }
}