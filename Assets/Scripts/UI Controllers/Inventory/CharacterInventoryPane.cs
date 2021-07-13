using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CharacterInventoryPane : MonoBehaviour
{
    public GameObject InventoryList;
    public GameObject EquipmentSlots;
    public GameObject itemDescriptionP;
    public GameObject ContextMenu;
    public GameObject ContextUse;
    public GameObject ContextEquip;
    public GameObject ContextQuickItem;
    public GameObject ContextQuit;
    public int ContextIndex;

    public Image itemImage;
    public Text itemDescription;
    public Text itemInfo;

    public Text moneyP;

    int numOfItems = 0;

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

    public void DisplayItemInfo(InventoryItem item)
    {
        itemDescriptionP.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        itemDescription.text = item.itemDescription;
    }

    public void DisplayContextMenu(InventoryItem item, int index)
    {
        ContextMenu.transform.position = Mouse.current.position.ReadValue();
        ContextIndex = index;
        if(item.usable)
        {
            ContextUse.SetActive(true);
            ContextQuickItem.SetActive(true);
        }
        if(item.itemType == ItemType.Equipment)
            ContextEquip.SetActive(true);
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
            slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentCharges.ToString() + "/" + item.maxCharges.ToString() + " Charges";
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
                slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentCharges.ToString() + "/" + item.maxCharges.ToString() + " Charges";
            else
                slot.transform.Find("StackCount").GetComponent<Text>().text = "";

            slot.transform.SetParent(InventoryList.transform);
            numOfItems++;
        }
        numOfItems = 0;
    }
}