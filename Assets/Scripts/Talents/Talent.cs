using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Talent
{
    public int TalentId = 0;
    public string TalentName = "Placeholder Talent";
}
//Magic exists in the world, no method exists of harnessing it.
//Magic use is limited to sources that intrinsically contain essence. (Flora, fauna, metals, etc.) You could make a limited use fire sword but you couldn't cast a fireball.
//Method of harnessing essence is found. (Magic language.)

//To allow modularity of talents.
//Essence is extracted from magic sources and imbued into ink.
//Talent tree is based off of magic ink being turned to runes that will be (somehow attached to you) to work as your talent tree.
//Problem 1. Near endless creation of runes. (Grinding mats to pump out runes til you get the best one. It wouldn't make sense to find runes in the world naturally.)
//Problem 2. How are they attached without occupying a lot of space? (Paper? Tattoos? Stone/metal chips?) Armor will get its own runes for enhancement.
//Problem 3. How can talents be limited based on character growth? (What stops you from just covering yourself in them?)