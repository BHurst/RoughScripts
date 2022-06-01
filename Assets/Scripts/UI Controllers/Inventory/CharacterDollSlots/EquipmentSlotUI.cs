using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane inventoryPane;
    public EquipmentSlot.SlotName slotName;

    private void Start()
    {
        if (inventoryPane == null)
            inventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
        inventoryPane.equipmentSlotUIs.Add(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var slot = PlayerCharacterUnit.player.unitEquipment.AllEquipment.Find(x => x.slotName == slotName);
        if (slot.itemInSlot != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                inventoryPane.DisplayItemInfo(slot.itemInSlot);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                inventoryPane.contextClicked = eventData.pointerPress.gameObject;
                inventoryPane.DisplayContextMenu(PlayerCharacterUnit.player.unitEquipment.AllEquipment.Find(x => x.slotName == slotName).itemInSlot);
            }
        }
    }

    public void Display()
    {
        var slot = PlayerCharacterUnit.player.unitEquipment.AllEquipment.Find(x => x.slotName == slotName);
        if (slot.itemInSlot != null)
            GetComponent<Image>().sprite = Resources.Load<Sprite>(slot.itemInSlot.itemImageLocation);
        else
            GetComponent<Image>().sprite = null;
    }
}