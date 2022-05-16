using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerHotbarAbilities
{
    public Ability hotbarSlot0;
    public HotbarAbilitySlot hotbarSlot0UI;
    public Ability hotbarSlot1;
    public HotbarAbilitySlot hotbarSlot1UI;
    public Ability hotbarSlot2;
    public HotbarAbilitySlot hotbarSlot2UI;
    public Ability hotbarSlot3;
    public HotbarAbilitySlot hotbarSlot3UI;
    public Ability hotbarSlot4;
    public HotbarAbilitySlot hotbarSlot4UI;
    public Ability hotbarSlot5;
    public HotbarAbilitySlot hotbarSlot5UI;
    public Ability hotbarSlot6;
    public HotbarAbilitySlot hotbarSlot6UI;
    public Ability hotbarSlot7;
    public HotbarAbilitySlot hotbarSlot7UI;
    public Ability hotbarSlot8;
    public HotbarAbilitySlot hotbarSlot8UI;
    public Ability hotbarSlot9;
    public HotbarAbilitySlot hotbarSlot9UI;

    public void PlaceSlot(Ability ability, int slotNum)
    {
        switch (slotNum)
        {
            case 0:
                hotbarSlot0 = ability;
                hotbarSlot0UI.PopulateSlot(ability);
                break;
            case 1:
                hotbarSlot1 = ability;
                hotbarSlot1UI.PopulateSlot(ability);
                break;
            case 2:
                hotbarSlot2 = ability;
                hotbarSlot2UI.PopulateSlot(ability);
                break;
            case 3:
                hotbarSlot3 = ability;
                hotbarSlot3UI.PopulateSlot(ability);
                break;
            case 4:
                hotbarSlot4 = ability;
                hotbarSlot4UI.PopulateSlot(ability);
                break;
            case 5:
                hotbarSlot5 = ability;
                hotbarSlot5UI.PopulateSlot(ability);
                break;
            case 6:
                hotbarSlot6 = ability;
                hotbarSlot6UI.PopulateSlot(ability);
                break;
            case 7:
                hotbarSlot7 = ability;
                hotbarSlot7UI.PopulateSlot(ability);
                break;
            case 8:
                hotbarSlot8 = ability;
                hotbarSlot8UI.PopulateSlot(ability);
                break;
            case 9:
                hotbarSlot9 = ability;
                hotbarSlot9UI.PopulateSlot(ability);
                break;
            default:
                break;
        }
    }

    public void RemoveSlot(int slotNum)
    {
        switch (slotNum)
        {
            case 0:
                hotbarSlot0 = null;
                hotbarSlot0UI.DepopulateSlot();
                break;
            case 1:
                hotbarSlot1 = null;
                hotbarSlot1UI.DepopulateSlot();
                break;
            case 2:
                hotbarSlot2 = null;
                hotbarSlot2UI.DepopulateSlot();
                break;
            case 3:
                hotbarSlot3 = null;
                hotbarSlot3UI.DepopulateSlot();
                break;
            case 4:
                hotbarSlot4 = null;
                hotbarSlot4UI.DepopulateSlot();
                break;
            case 5:
                hotbarSlot5 = null;
                hotbarSlot5UI.DepopulateSlot();
                break;
            case 6:
                hotbarSlot6 = null;
                hotbarSlot6UI.DepopulateSlot();
                break;
            case 7:
                hotbarSlot7 = null;
                hotbarSlot7UI.DepopulateSlot();
                break;
            case 8:
                hotbarSlot8 = null;
                hotbarSlot8UI.DepopulateSlot();
                break;
            case 9:
                hotbarSlot9 = null;
                hotbarSlot9UI.DepopulateSlot();
                break;
            default:
                break;
        }
    }

}