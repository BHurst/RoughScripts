using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextUnequip : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    public void OnPointerClick(PointerEventData eventData)
    {
        var slotInContext = GameWorldReferenceClass.GW_Player.unitEquipment.AllEquipment.Find(x => x.slotName == characterInventoryPane.contextClicked.GetComponent<EquipmentSlotUI>().slotName);

        GameWorldReferenceClass.GW_Player.charInventory.UnequipToInventory(slotInContext.itemInSlot);
        GameWorldReferenceClass.GW_Player.unitEquipment.RemoveEquipment(slotInContext.itemInSlot.fitsInSlot.name);
        characterInventoryPane.RefreshAllEquipmentUISlots();
        characterInventoryPane.ClearItemInfo();
        characterInventoryPane.CloseContext();
    }
}