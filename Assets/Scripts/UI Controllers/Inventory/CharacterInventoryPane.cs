using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CharacterInventoryPane : MonoBehaviour
{
    public GameObject InventoryList;
    public GameObject EquipmentSlots;
    public GameObject itemDescriptionP;
    public Canvas canv;
    public bool initialLoad;

    public Image itemImage;
    public Text itemDescription;
    public Text itemInfo;

    public Text moneyP;

    int numOfItems = 0;

    public void DisplayItemInfo(InventoryItem item)
    {
        itemDescriptionP.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        itemDescription.text = item.itemDescription;
    }

    public void RemoveItem(int index)
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