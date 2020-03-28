using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass
{
    public enum CharClass
    {
        Civilian,
        /*For those that do not seek to claim their potential.
         Style: Current fashion
         Abilities: Nada
         */


        Monk,
        /*Physical and supernatural enchancments and control for those with discipline
         Style: Physical attacks with various buffs. Minor utility.
         Abilities: tbd
         */
            //Subclasses

            Monk_Of_Prime_Force,
            /*Very fast barehand combat
             Style: Fast physical attacks. Evasive.
             Abilities: tbd
             */
            Six_Point_Monk,
            /*Enhancements, Enhancements, Enhancements. Buffs of all worldly flavors.
             Style: Frequent short duration buffs for most skills.
             Abilities: tbd
             */


        Mage,
        /*Raw magic and speed for those in need of power
         Style: Elemental and arcane spells. Pure mental power.
         Abilities: tbd
         */
            //Subclasses

            Weave_Mage,
            /*Meta magic. Great handle for casting control spells.
             Style: Crowd Control. Ability nullification, absorbs, redirects.
             Abilities: tbd
             */
            Archmage,
            /*Advanced mage. Greater variation on spells but retains the same focus and purpose.
             Style: Pooooowweeeeerrrrr.
             Abilities: tbd
             */


        Druid,
        /*For working with the natural energies that permeate the wilds.
         Style: Large utility with a strong focus on area effects.
         Abilities: tbd
         */
            //Subclasses

            Primal_Druid,
            /*Animalist powers. Summons a type of beast.
             Style: Ringmaster. Equipped with chair and whip.
             Abilities: tbd
             */
            Nature_Druid,
            /*Primarily nature based magic. Restoration and plant based spells.
             Style: Toxicity and restoration.
             Abilities: tbd
             */


        Adherent,
        /*Cosmic and spiritual energy for those with the will to remake the world.
         Style: Meddles with life and resources. Notable for debuffs and ailments.
         Abilities: tbd
         */
            //Subclasses

            Astromancer,
            /*Cosmic power. Generaly deals with matter manipulation.
             Style: Everything is a weapon.
             Abilities: tbd
             */
            Spirit_Usher,
            /*Focus on spirit manipulation. Debuffs of all kinds.
             Style: Makes existing an annoyance.
             Abilities: tbd
             */


        Adventurer,
        /*Practical everyday guerilla tactics. Thrive and explore via any means.
         Style: Resourceful and underhanded. Able to handle many different situations.
         Abilities: tbd
         */
            //Subclasses

            Alchemist,
            /*Potions and vials and some dye for style.
             Style: Persistant area effects.
             Abilities: tbd
             */
            Rogue,
            /*So many knives you wouldn't even believe.
             Style: Make everything that doesn't have holes, have holes.
             Abilities: tbd
             */


        Warrior,
        /*Can take quite a few hits. Can also give them out too.
         Style: Strait forward physical attacks.
         Abilities: tbd
         */
             //Subclasses

             Shield_Bearer,
            /*Can't dent this.
             Style: Massive defense. Imposing presence to diminish attackers.
             Abilities: tbd
             */
            Knight,
            /*Really big weapons
             Style: You're going to need two appendages for these at least.
             Abilities: tbd
             */
        
        
        
        
        //Multiclasses
        
            Enhancement_Monk,//Monk-Mage
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Spiritualist,//Monk-Druid
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Eternal_Monk,//Monk-Adherent
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Wanderer,//Monk-Adventurer
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            World_Bearer,//Monk-Warrior
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Elementalist,//Mage-Druid
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            World_Shaper,//Mage-Adherent
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Trickster,//Mage-Adventurer
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            BattleMage,//Mage-Warrior
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Summoner,//Druid-Adherent
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Survivalist,//Druid-Adventurer
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Juggernaut,//Druid-Warrior
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Outlander,//Adherent-Adventurer
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Twilight_Soldier,//Adherent-Warrior
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
            Weapon_Master//Adventurer-Warrior
            /*Can take quite a few hits. Can also give them out too.
             Style: Strait forward physical attacks.
             Abilities: tbd
             */
    }

    public CharClass ActiveCharacterClass = CharClass.Civilian;
}