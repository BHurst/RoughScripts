using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SingleInventorySlotScript : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane inventoryPane;
    public int inventoryIndex;
    public InventoryItem itemInSlot;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStack;
    public Image itemImage;

    private void Start()
    {
        inventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void DefaultCreation()
    {
        SetStack();
        SetName();
        SetImage();
    }

    public void SetStack()
    {
        if (itemInSlot.stackable)
            itemStack.SetText(itemInSlot.currentStackSize.ToString() + "/" + itemInSlot.maxStackSize.ToString());
        else if (itemInSlot.usable)
            itemStack.SetText(((ConsumableHealItem)itemInSlot).currentUses.ToString() + "/" + ((ConsumableHealItem)itemInSlot).maxUses.ToString() + " Uses");
        else
            itemStack.SetText("");
    }

    public void SetName()
    {
        itemName.SetText(itemInSlot.itemName);
    }

    public void SetImage()
    {
        itemImage.sprite = Resources.Load<Sprite>(itemInSlot.itemImageLocation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryPane.DisplayItemInfo(itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryPane.contextClicked = eventData.pointerPress.gameObject;
            inventoryPane.DisplayContextMenu(itemInSlot, inventoryIndex);
        }
    }
}