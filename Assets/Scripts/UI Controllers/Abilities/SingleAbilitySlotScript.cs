using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleAbilitySlotScript : MonoBehaviour
{
    public int slotIndex;
    public Sprite abilityInSlotImage;
    public Image cooldownImage;
    Cooldown coolingdownAbility;
    RootAbility abilityInSlot;

    private void Start()
    {
        
    }

    public void SlotClick()
    {
        GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].SlotClick();
    }

    public void SlotDrag()
    {
        GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].SlotDrag();
    }

    public void SlotDrop()
    {
        GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].SlotDrop();
    }

    void Update()
    {
        if(GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].hasAbility)
        {
            abilityInSlot = GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId);

            coolingdownAbility = GameWorldReferenceClass.GW_Player.abilitiesOnCooldown.cooldowns.Find(x => x.id == abilityInSlot.abilityID);

            if (coolingdownAbility != null)
            {
                cooldownImage.fillAmount = Mathf.Clamp(((coolingdownAbility.currentCd / coolingdownAbility.maxCd) - 1) * -1, 0, 1);
            }
            else
            {
                cooldownImage.fillAmount = 1;
            }
        }
    }
}