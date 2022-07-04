using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResponseRequirement
{
    public RequirementType requirementType;
    public bool loseRequirement = false;
    public int itemID;

    public string ReadableRequirement()
    {
        return itemID.ToString();
    }

    public void LostRequirement()
    {
        switch (requirementType)
        {
            case RequirementType.None:
                break;
            case RequirementType.Item:
                PlayerCharacterUnit.player.charInventory.RemoveItemByID(itemID);
                break;
            default:
                break;
        }
    }

    public enum RequirementType
    {
        None,
        Item
    }
}