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
        EquipmentSlot.SlotName slotNameInContext = UIManager.main.contextMenu.contextClicked.GetComponent<EquipmentSlotUI>().slotName;
        UIManager.main.contextMenu.HideMenu();

        PlayerCharacterUnit.player.unitEquipment.RemoveEquipment(slotNameInContext);
        characterInventoryPane.RefreshAllEquipmentUISlots();
        characterInventoryPane.ClearItemInfo();
    }
}