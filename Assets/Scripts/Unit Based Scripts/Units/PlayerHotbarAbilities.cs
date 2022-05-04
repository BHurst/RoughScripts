using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerHotbarAbilities
{
    public Ability hotbarSlot0;
    public SingleAbilitySlotScript hotbarSlot0UI;
    public Ability hotbarSlot1;
    public SingleAbilitySlotScript hotbarSlot1UI;
    public Ability hotbarSlot2;
    public SingleAbilitySlotScript hotbarSlot2UI;
    public Ability hotbarSlot3;
    public SingleAbilitySlotScript hotbarSlot3UI;
    public Ability hotbarSlot4;
    public SingleAbilitySlotScript hotbarSlot4UI;
    public Ability hotbarSlot5;
    public SingleAbilitySlotScript hotbarSlot5UI;
    public Ability hotbarSlot6;
    public SingleAbilitySlotScript hotbarSlot6UI;
    public Ability hotbarSlot7;
    public SingleAbilitySlotScript hotbarSlot7UI;
    public Ability hotbarSlot8;
    public SingleAbilitySlotScript hotbarSlot8UI;
    public Ability hotbarSlot9;
    public SingleAbilitySlotScript hotbarSlot9UI;

    public void PlaceSlot0(Ability ability)
    {
        hotbarSlot0 = ability;
        hotbarSlot0UI.PopulateSlot(ability);
    }

    public void PlaceSlot1(Ability ability)
    {
        hotbarSlot1 = ability;
        hotbarSlot1UI.PopulateSlot(ability);
    }

    public void PlaceSlot2(Ability ability)
    {
        hotbarSlot2 = ability;
        hotbarSlot2UI.PopulateSlot(ability);
    }

    public void PlaceSlot3(Ability ability)
    {
        hotbarSlot3 = ability;
        hotbarSlot3UI.PopulateSlot(ability);
    }

    public void PlaceSlot4(Ability ability)
    {
        hotbarSlot4 = ability;
        hotbarSlot4UI.PopulateSlot(ability);
    }

    public void PlaceSlot5(Ability ability)
    {
        hotbarSlot5 = ability;
        hotbarSlot5UI.PopulateSlot(ability);
    }

    public void PlaceSlot6(Ability ability)
    {
        hotbarSlot6 = ability;
        hotbarSlot6UI.PopulateSlot(ability);
    }

    public void PlaceSlot7(Ability ability)
    {
        hotbarSlot7 = ability;
        hotbarSlot7UI.PopulateSlot(ability);
    }

    public void PlaceSlot8(Ability ability)
    {
        hotbarSlot8 = ability;
        hotbarSlot8UI.PopulateSlot(ability);
    }

    public void PlaceSlot9(Ability ability)
    {
        hotbarSlot9 = ability;
        hotbarSlot9UI.PopulateSlot(ability);
    }

    public Ability SwapSlot0(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot1(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot2(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot3(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot4(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot5(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot6(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot7(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot8(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }

    public Ability SwapSlot9(Ability ability)
    {
        Ability oldAbility = hotbarSlot0;
        hotbarSlot0 = ability;
        return oldAbility;
    }
}