using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickItemSlot : MonoBehaviour
{
    public Image icon;
    public Text stackCount;
    public Image fade;
    public int itemID;
    public bool empty;

    public void SetQuickItem(InventoryItem item)
    {
        icon.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        stackCount.text = item.currentReserve + "/" + item.maxReserve;
        itemID = item.itemID;
        GameWorldReferenceClass.GW_Player.quickItem = item;
        fade.gameObject.SetActive(false);
        empty = false;
    }

    public bool FindNextOfSame()
    {
        InventoryItem next = GameWorldReferenceClass.GW_Player.charInventory.Inventory.Find(x => x.itemID == itemID);
        if (next != null)
        {
            SetQuickItem(next);
            return true;
        }
        empty = true;
        return false;
    }

    public void UseQuickItem(InventoryItem item)
    {
        if(item.currentReserve > 0)
        {
            GameWorldReferenceClass.GW_Player.charInventory.UseItem(item);
            
            if (item.currentReserve == 0)
            {
                if (!FindNextOfSame())
                {
                    fade.gameObject.SetActive(true);
                    stackCount.text = item.currentReserve + "/" + item.maxReserve;
                }
            }
            else
                stackCount.text = item.currentReserve + "/" + item.maxReserve;
        }
    }
}