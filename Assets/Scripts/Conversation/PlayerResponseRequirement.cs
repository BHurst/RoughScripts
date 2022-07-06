using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerResponseRequirement
{
    public RequirementType requirementType;
    public bool requirementLostWhenMet = false;
    public int ItemRequirement_itemID;
    public int QuestRequirement_id;
    public int QuestRequirement_questPhase;

    public string ReadableRequirement()
    {
        switch (requirementType)
        {
            case RequirementType.None:
                return "None";
            case RequirementType.Flag:
                return "None";
            case RequirementType.Item:
                return ItemRequirement_itemID.ToString();
            case RequirementType.Quest:
                return QuestManager.GetQuestByID(QuestRequirement_id).questName;
            default:
                return "None";
        }
    }

    public static bool CheckRequirements(List<PlayerResponseRequirement> requirements)
    {
        bool requirementsMet = false;
        foreach (PlayerResponseRequirement requirement in requirements)
        {
            switch (requirement.requirementType)
            {
                case RequirementType.Flag:
                    break;
                case RequirementType.Item:
                    if (PlayerCharacterUnit.player.charInventory.CheckItem(requirement.ItemRequirement_itemID))
                        requirementsMet = true;
                    else
                        requirementsMet = false;
                    break;
                case RequirementType.Quest:
                    if (QuestManager.GetQuestByID(requirement.QuestRequirement_id).phase >= requirement.QuestRequirement_questPhase)
                        requirementsMet = true;
                    else
                        requirementsMet = false;
                    break;
                default:
                    requirementsMet = false;
                    break;
            }
            if (!requirementsMet)
                return false;
        }
        return true;
    }

    public void TakeRequirement()
    {
        switch (requirementType)
        {
            case RequirementType.None:
                break;
            case RequirementType.Flag:
                break;
            case RequirementType.Item:
                PlayerCharacterUnit.player.charInventory.RemoveItemByID(ItemRequirement_itemID);
                break;
            case RequirementType.Quest:
                break;
            default:
                break;
        }
    }

    public enum RequirementType
    {
        None,
        Flag,
        Item,
        Quest
    }
}