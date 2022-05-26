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
    public List<EquipmentSlotUI> equipmentSlotUIs;

    int numOfItems = 0;

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject statLine = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/UI_InventoryItemStatLine")) as GameObject;
            itemStatLines.Add(statLine);
            statLine.transform.SetParent(itemInfoText);
            statLine.SetActive(false);
        }
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        HideHiddenText();
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
    }

    public void RigEvents()
    {
        GameWorldReferenceClass.GW_Player.charInventory.ItemUsed += CharInventory_ItemUsed;
        GameWorldReferenceClass.GW_Player.charInventory.ItemDepleted += CharInventory_ItemDepleted;
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
            if (((EquipmentInventoryItem)item).mods.Count > 0)
                itemStatHeader.SetActive(true);

            for (int i = 0; i < itemStatLines.Count; i++)
            {
                if (((EquipmentInventoryItem)item).mods.Count > i)
                {
                    itemStatLines[i].transform.Find("Stat").GetComponent<TextMeshProUGUI>().SetText(((EquipmentInventoryItem)item).mods[i].ReadableName());

                    InformationTags.InfoTag statCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(((EquipmentInventoryItem)item).mods[i].Stat.ToString(), out statCheck);
                    InformationTags.InfoTag aspectCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(((EquipmentInventoryItem)item).mods[i].Aspect.ToString(), out aspectCheck);
                    InformationTags.InfoTag methodCheck = InformationTags.InfoTag.None;
                    Enum.TryParse(((EquipmentInventoryItem)item).mods[i].Method.ToString(), out methodCheck);

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
            //info += "Rune Modifiers:\n\n";
            //if (((EquipmentInventoryItem)item).locusRune != null && ((EquipmentInventoryItem)item).locusRune.simpleTalents.Count > 0)
            //{
            //    foreach (var rune in ((EquipmentInventoryItem)item).locusRune.simpleTalents)
            //    {
            //        foreach (var mod in rune.modifiers)
            //            info += " - " + mod.ReadableName() + "\n";
            //    }
            //}
            //if (((EquipmentInventoryItem)item).locusRune != null && ((EquipmentInventoryItem)item).locusRune.complexTalents.Count > 0)
            //{
            //    foreach (var rune in ((EquipmentInventoryItem)item).locusRune.complexTalents)
            //    {
            //        info += " - " + rune.talentDescription + "\n";
            //    }
            //}


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
        var item = GameWorldReferenceClass.GW_Player.charInventory.Inventory[index];
        var slot = InventoryList.transform.GetChild(index);

        if (item.stackable)
            slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentStackSize.ToString() + "/" + item.maxStackSize.ToString();
        else if (item.usable)
            slot.transform.Find("StackCount").GetComponent<Text>().text = ((ConsumableHealItem)item).currentUses.ToString() + "/" + ((ConsumableHealItem)item).maxUses.ToString() + " Reserve";
        else
            slot.transform.Find("StackCount").GetComponent<Text>().text = "";
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
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

            slot.GetComponent<SingleInventorySlotScript>().inventoryIndex = numOfItems;
            slot.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
            if (item.itemImageLocation != "Items/")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.itemImageLocation);

            if (item.stackable)
                slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentStackSize.ToString() + "/" + item.maxStackSize.ToString();
            else if (item.usable)
                slot.transform.Find("StackCount").GetComponent<Text>().text = ((ConsumableHealItem)item).currentUses.ToString() + "/" + ((ConsumableHealItem)item).maxUses.ToString() + " Reserve";
            else
                slot.transform.Find("StackCount").GetComponent<Text>().text = "";

            slot.transform.SetParent(InventoryList.transform);
            numOfItems++;
        }
        numOfItems = 0;
    }

    public void AddInventorySlot(InventoryItem item)
    {
        numOfItems = InventoryList.transform.childCount;

        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

        slot.GetComponent<SingleInventorySlotScript>().inventoryIndex = numOfItems;
        slot.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
        if (item.itemImageLocation != "Items/")
            slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.itemImageLocation);

        if (item.stackable)
            slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentStackSize.ToString() + "/" + item.maxStackSize.ToString();
        else if (item.usable)
            slot.transform.Find("StackCount").GetComponent<Text>().text = ((ConsumableHealItem)item).currentUses.ToString() + "/" + ((ConsumableHealItem)item).maxUses.ToString() + " Reserve";
        else
            slot.transform.Find("StackCount").GetComponent<Text>().text = "";

        slot.transform.SetParent(InventoryList.transform);
        numOfItems = 0;
    }
}