using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class CharacterInventoryPane : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject InventoryList;
    public GameObject itemDescriptionPanel;
    public GameObject contextClicked;
    public GameObject ContextMenu;
    public GameObject ContextUse;
    public GameObject ContextEquip;
    public GameObject ContextUnequip;
    public GameObject ContextQuickItem;
    public GameObject ContextQuit;
    public int ContextIndex;
    public string ContextSlot;

    public Image itemImage;
    public GameObject itemStatHeader;
    public TextMeshProUGUI itemDescriptionText;
    public RectTransform itemInfoText;
    public List<GameObject> itemStatLines;
    public Transform equipmentSlotParent;
    public List<EquipmentSlotUI> equipmentSlotUIs;
    public List<SingleInventorySlotScript> inventorySlots;

    int numOfItems = 0;

    private void Start()
    {
        mainPanel.transform.position = transform.position;
        for (int i = 0; i < 6; i++)
        {
            GameObject statLine = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/UI_InventoryItemStatLine")) as GameObject;
            itemStatLines.Add(statLine);
            statLine.transform.SetParent(itemInfoText);
            statLine.SetActive(false);
        }
        foreach (Transform child in equipmentSlotParent)
            equipmentSlotUIs.Add(child.GetComponent<EquipmentSlotUI>());
        mainPanel.SetActive(false);
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        RefreshAllEquipmentUISlots();
        HideHiddenText();
    }

    public void Hide()
    {
        CloseContext();
        mainPanel.SetActive(false);
    }

    public void RigEvents()
    {
        PlayerCharacterUnit.player.charInventory.ItemUsed += CharInventory_ItemUsed;
        PlayerCharacterUnit.player.charInventory.ItemDepleted += CharInventory_ItemDepleted;
    }

    private void CharInventory_ItemDepleted(object sender, int e)
    {
        RemoveInventorySlot(e);
    }

    private void CharInventory_ItemUsed(object sender, int e)
    {
        RefreshIndex(e);
    }

    public void ClearItemInfo()
    {
        //itemInfoText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionPanel.SetActive(false);
    }

    public void ClearFilter()
    {
        foreach (SingleInventorySlotScript slot in inventorySlots)
        {
            slot.gameObject.SetActive(true);
        }
    }

    public void FilterInventory(InventoryItem.ItemType itemType, EquipmentSlot.SlotType slotType)
    {
        if (itemType == InventoryItem.ItemType.None && slotType == EquipmentSlot.SlotType.None)
        {
            ClearFilter();
            return;
        }

        foreach (SingleInventorySlotScript slot in inventorySlots)
        {
            if ((itemType == InventoryItem.ItemType.None || slot.itemInSlot.itemType == itemType) && (slotType == EquipmentSlot.SlotType.None || (slot.itemInSlot.itemType == InventoryItem.ItemType.Equipment && ((EquipmentInventoryItem)slot.itemInSlot).slotType == slotType)))
            {
                slot.gameObject.SetActive(true);
            }
            else
                slot.gameObject.SetActive(false);

        }
    }

    public void RefreshAllEquipmentUISlots()
    {
        foreach (var slot in equipmentSlotUIs)
        {
            slot.Display();
        }
    }

    public void RefreshEquipmentUISlot(EquipmentSlotUI slot)
    {
        slot.Display();
    }

    public void ShowHiddenText()
    {
        foreach (var item in itemStatLines)
        {
            item.transform.Find("Description").GetComponent<CanvasRenderer>().SetAlpha(1);
        }
    }

    public void HideHiddenText()
    {
        foreach (var item in itemStatLines)
        {
            item.transform.Find("Description").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }

    public void DisplayItemInfo(InventoryItem item)
    {
        itemDescriptionPanel.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        itemDescriptionText.text = item.itemDescription;

        if (item.itemType == InventoryItem.ItemType.Equipment)
        {
            EquipmentInventoryItem itemAsEII = (EquipmentInventoryItem)item;

            if (itemAsEII.mods.Count > 0)
                itemStatHeader.SetActive(true);

            for (int i = 0; i < itemStatLines.Count; i++)
            {
                if (itemAsEII.mods.Count > i)
                {
                    itemStatLines[i].transform.Find("Stat").GetComponent<TextMeshProUGUI>().SetText(itemAsEII.mods[i].ReadableName());

                    InformationTags.InfoTag statCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(itemAsEII.mods[i].Stat.ToString(), out statCheck);
                    InformationTags.InfoTag aspectCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(itemAsEII.mods[i].Aspect.ToString(), out aspectCheck);
                    InformationTags.InfoTag methodCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(itemAsEII.mods[i].Method.ToString(), out methodCheck);

                    string description = "";
                    description = (InformationTags.GetTagInfo(statCheck) + " " + InformationTags.GetTagInfo(aspectCheck) + " " + InformationTags.GetTagInfo(methodCheck)).Trim();
                    itemStatLines[i].transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText(description);
                    itemStatLines[i].SetActive(true);
                }
                else
                {
                    itemStatLines[i].SetActive(false);
                }
            }
            if(!RootAbility.NullorUninitialized(itemAsEII.attatchedAbility))
            {
                itemDescriptionText.text += "\n" + itemAsEII.attatchedAbility.abilityName + 
                    "\n" + itemAsEII.attatchedAbility.GetCost() + " Mana" + 
                    "\n" + itemAsEII.attatchedAbility.GetCastTime() + "s" + 
                    "\n" + itemAsEII.attatchedAbility.GetAbilityDescription();
            }
        }
        else
        {
            itemStatHeader.SetActive(false);
        }
        HideHiddenText();
        LayoutRebuilder.ForceRebuildLayoutImmediate(itemInfoText);
    }

    public void DisplayContextMenu(InventoryItem item, int index)
    {
        ContextMenu.transform.position = Mouse.current.position.ReadValue();
        ContextIndex = index;
        if (item.usable)
        {
            ContextUse.SetActive(true);
            ContextQuickItem.SetActive(true);
        }
        if (item.itemType == InventoryItem.ItemType.Equipment)
            ContextEquip.SetActive(true);
        ContextMenu.SetActive(true);
        ContextQuit.SetActive(true);
    }

    public void DisplayContextMenu(EquipmentInventoryItem item)
    {
        ContextMenu.transform.position = Mouse.current.position.ReadValue();
        ContextUnequip.SetActive(true);
        ContextMenu.SetActive(true);
        ContextQuit.SetActive(true);
    }

    public void CloseContext()
    {
        foreach (Transform child in ContextMenu.transform)
            child.gameObject.SetActive(false);
        ContextMenu.SetActive(false);
        ContextQuit.SetActive(false);
    }

    public void RefreshIndex(int index)
    {
        var item = PlayerCharacterUnit.player.charInventory.Inventory[index];
        SingleInventorySlotScript slot = InventoryList.transform.GetChild(index).GetComponent<SingleInventorySlotScript>();

        slot.SetStack();
    }

    public void RemoveInventorySlot(int index)
    {
        if (InventoryList.transform.childCount > 0)
            for (int i = index; i < InventoryList.transform.childCount; i++)
            {
                InventoryList.transform.GetChild(i).GetComponent<SingleInventorySlotScript>().inventoryIndex--;
            }
        Destroy(InventoryList.transform.GetChild(index).gameObject);
    }

    public void AddInventorySlot(List<InventoryItem> itemList)
    {
        numOfItems = InventoryList.transform.childCount;
        foreach (InventoryItem item in itemList)
        {
            GameObject newObj = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

            SingleInventorySlotScript slot = newObj.GetComponent<SingleInventorySlotScript>();
            slot.itemInSlot = item;
            slot.inventoryIndex = numOfItems;
            slot.DefaultCreation();

            newObj.transform.SetParent(InventoryList.transform);
            inventorySlots.Add(slot);
            numOfItems++;
        }
        numOfItems = 0;
    }

    public void AddInventorySlot(InventoryItem item)
    {
        numOfItems = InventoryList.transform.childCount;

        GameObject newObj = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

        SingleInventorySlotScript slot = newObj.GetComponent<SingleInventorySlotScript>();
        slot.itemInSlot = item;
        slot.inventoryIndex = numOfItems;
        slot.DefaultCreation();

        slot.transform.SetParent(InventoryList.transform);
        inventorySlots.Add(slot);
        numOfItems = 0;
    }
}