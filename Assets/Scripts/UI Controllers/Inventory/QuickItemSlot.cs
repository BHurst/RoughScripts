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

    public void SetQuickItem(ConsumableInventoryItem item)
    {
        icon.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        stackCount.text = item.currentUses + "/" + item.maxUses;
        itemID = item.itemID;
        PlayerCharacterUnit.player.quickItem = item;
        fade.gameObject.SetActive(false);
        empty = false;
    }

    public bool FindNextOfSame()
    {
        InventoryItem next = PlayerCharacterUnit.player.charInventory.Inventory.Find(x => x.itemID == itemID);
        if (next != null)
        {
            SetQuickItem((ConsumableInventoryItem)next);
            return true;
        }
        empty = true;
        return false;
    }

    public void UseQuickItem(ConsumableInventoryItem item)
    {
        if(item.currentUses > 0)
        {
            PlayerCharacterUnit.player.charInventory.UseItem(item);
            
            if (item.currentUses == 0)
            {
                if (!FindNextOfSame())
                {
                    fade.gameObject.SetActive(true);
                    stackCount.text = item.currentUses + "/" + item.maxUses;
                }
            }
            else
                stackCount.text = item.currentUses + "/" + item.maxUses;
        }
    }
}