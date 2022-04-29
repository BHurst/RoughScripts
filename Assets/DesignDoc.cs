using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DesignDoc
{
    #region Abilities
    #region General
    //---General
    //All abilities have a:
    //  Form, the physical representation of how they exist in the world.
    //  School, the classification for what type of "material" they are made up of.
    //  Cast Mode, the process required for a character to create it.
    #endregion
    #region Schools
    /*Vague outline of the values below. Not based on any actual numbers
     * ---damage by rank
     * 1 - 55
     * 2 - 60
     * 3 - 67
     * 4 - 74
     * 5 - 81
     * 6 - 89
     * 7 - 98
     * 8 - 108
     * 9 - 118
     * 10 - 130
     * 11 - 143
     * 12 - 157
     * 13 - 173
     * 14 - 190
     * 16 - 209
     * 17 - 230
     * 18 - 253
     * 19 - 278
     * 20 - 306
     * ---damage modifier
     * 0 - .5x
     * 1 - .6x
     * 2 - .7x
     * 3 - .8x
     * 4 - .9x
     * 5 - 1x
     * 6 - 1.4x
     * 7 - 1.8x
     * 8 - 2.2x
     * 9 - 2.6x
     * 10 - 3x
     *---cast speed
     * 0 - 4
     * 1 - 3.6
     * 2 - 3.2
     * 3 - 2.8
     * 4 - 2.4
     * 5 - 2
     * 6 - 1.8
     * 7 - 1.6
     * 8 - 1.4
     * 9 - 1.2
     * 10 - 1
     *---cost
     * 0 - 20
     * 1 - 18
     * 2 - 16
     * 3 - 14
     * 4 - 12
     * 5 - 10
     * 6 - 9
     * 7 - 8
     * 8 - 7
     * 9 - 6
     * 10 - 5
     *---cd
     * 0 - 0
     * 1 - 1
     * 2 - 2
     * 3 - 3
     * 4 - 4
     * 5 - 5
     * 6 - 7
     * 7 - 9
     * 8 - 11
     * 9 - 13
     * 10 - 15
     * 
    * Air
    *   In a base sense, it is power over the general gases of the atmosphere. With further classification it can be any gas. Subtyping to Water would be steam; Life to plague/poison, etc..
    *   --
    *   Damage: 1
    *   Speed: 9
    *   Efficiency: 8
    *   Area: 7
    *   Duration: 3
    *   Utility: 5
    *   33
    *Arcane
    *   Raw power. Peak destructive force. Little control to be had over limiting what it will affect.
    *   --
    *   Damage: 10
    *   Speed: 5
    *   Efficiency: 4
    *   Area: 3
    *   Duration: 2
    *   Utility: 2
    *   26
    *Astral
    *   Fundemantal power over matter. Cosmically backed force. Fabric of reality type of influence. Very difficult to wield productively.
    *   --
    *   Damage: 6
    *   Speed: 1
    *   Efficiency: 0
    *   Area: 6
    *   Duration: 6
    *   Utility: 10
    *   31
    *Earth
    *   Power over stone/dirt/metal, the inanimate.
    *   --
    *   Damage: 5
    *   Speed: 5
    *   Efficiency: 6
    *   Area: 5
    *   Duration: 8
    *   Utility: 2
    *   31
    *Electricity
    *   What it says on the tin.
    *   --
    *   Damage: 8
    *   Speed: 6
    *   Efficiency: 7
    *   Area: 2
    *   Duration: 1
    *   Utility: 2
    *   26
    *Ethereal
    *   Power over the soul. Magic within all life created from naturally occuring means. Astral roots, not Arcane animation.
    *   --
    *   Damage: 5
    *   Speed: 5
    *   Efficiency: 8
    *   Area: 2
    *   Duration: 8
    *   Utility: 7
    *   35
    *Fire
    *   Control of heat. Magic fire can be hot, but the source of the heat is not through combustion of matter but through the consumption of magic within the matter. While water does not put out fire via
    *   smothering like normal fire, it displaces the fire so as to prevent it from being able to continue consuming its fuel.
    *   --
    *   Damage: 9
    *   Speed: 4
    *   Efficiency: 3
    *   Area: 6
    *   Duration: 4
    *   Utility: 2
    *   28
    *Ice
    *   In a simple sense, the opposite of fire in direction. Control of heat, but not self replicating. Magic ice is in a sense "magically cold", and remains cold unless burned via magic fire.
    *   Essentially magic in a solid form.
    *   Control has still be wielded over normal matter and can draw heat from objects in a normal sense.
    *   Magic ice's purpose is more suited to halting the effects of other forms of magic.
    *   --
    *   Damage: 3
    *   Speed: 5
    *   Efficiency: 6
    *   Area: 2
    *   Duration: 9
    *   Utility: 7
    *   32
    *Kinetic
    *   Just about the lowest form of magical control, as it only interacts with normal matter.
    *   --
    *   Damage: 6
    *   Speed: 10
    *   Efficiency: 10
    *   Area: 3
    *   Duration: 1
    *   Utility: 1
    *   30
    *Life
    *   Power over naturally occuring matter with a will. The other half of ethereal.
    *   --
    *   Damage: 2
    *   Speed: 2
    *   Efficiency: 8
    *   Area: 5
    *   Duration: 8
    *   Utility: 9
    *   34
    *Water
    *   Power over liquids, much in the same sense as air.
    *   --
    *   Damage: 3
    *   Speed: 6
    *   Efficiency: 8
    *   Area: 8
    *   Duration: 6
    *   Utility: 5
    *   34
    *------------   
    *   Air, Life, and Water are the weakest elements in straight damage. Due to their nature, their ability
    */
    #endregion
    #region Forms
    #endregion
    #region Cast Modes
    #endregion
    #region Talents
    /*
     */
    #endregion
    #region Equipment
    /*
     */
    #endregion
    #region Enemies
    /*
     */
    #endregion
    #endregion
}