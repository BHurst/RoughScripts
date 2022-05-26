using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextUnequip : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EquipmentSlot.SlotName slotNameInContext = characterInventoryPane.contextClicked.GetComponent<EquipmentSlotUI>().slotName;

        GameWorldReferenceClass.GW_Player.unitEquipment.RemoveEquipment(slotNameInContext);
        characterInventoryPane.RefreshAllEquipmentUISlots();
        characterInventoryPane.ClearItemInfo();
        characterInventoryPane.CloseContext();
    }
}