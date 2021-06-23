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
        
    }
}