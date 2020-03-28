using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarPane : MonoBehaviour
{
    static int hotbarPlaceholder;
    static GameObject abilitySlot;
    public GameObject heldAbilitySlot;
    public Canvas canv;
    Vector3 heldItemOffset = new Vector3(-40, 0, 0);

    public static void FillHotbar(RootUnit unit)
    {
        hotbarPlaceholder = 0;
        foreach (RootAbility ability in unit.availableAbilities)
        {
            abilitySlot = GameObject.Find("HotbarSlot" + hotbarPlaceholder.ToString());
            abilitySlot.GetComponentInChildren<Text>().text = ability.stats.abilityName;
            unit.hotbarAbilities[hotbarPlaceholder].hasAbility = true;
            unit.hotbarAbilities[hotbarPlaceholder].abilityInSlotId = ability.abilityID;
            hotbarPlaceholder++;
        }
    }

    public static void RefreshHotbar()
    {
        hotbarPlaceholder = 0;
        foreach (AbilitySlot slot in GameWorldReferenceClass.GW_Player.hotbarAbilities)
        {
            abilitySlot = GameObject.Find("HotbarSlot" + hotbarPlaceholder.ToString());
            abilitySlot.GetComponentInChildren<Text>().text = GameWorldReferenceClass.GetAbilityNameFromId(GameWorldReferenceClass.GW_Player, slot.abilityInSlotId);
            hotbarPlaceholder++;
        }
    }

    private void Update()
    {
        if (GameWorldReferenceClass.HeldAbility.hasAbility == true)
        {
            if (heldAbilitySlot.activeInHierarchy == false)
            {
                heldAbilitySlot.SetActive(true);
                //heldAbilitySlot.GetComponent<Image>().sprite = Resources.Load<Sprite>(GameWorldReferenceClass.HeldItem.itemInSlot.iStats.itemImageLocation);
                heldAbilitySlot.GetComponentInChildren<Text>().text = GameWorldReferenceClass.GetAbilityNameFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.HeldAbility.abilityInSlotId);
            }
            heldAbilitySlot.transform.position = Input.mousePosition + heldItemOffset * canv.scaleFactor;
        }
        else
        {
            heldAbilitySlot.SetActive(false);
        }
    }
}