using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupPanel : MonoBehaviour
{
    public GameObject content;
    public GameObject player;

    private void Awake()
    {
        player.GetComponent<RootUnit>().charInventory.ItemPickedUp += CharInventoryPanel_ItemPickedUp;
    }

    private void CharInventoryPanel_ItemPickedUp(object sender, InventoryItem e)
    {
        AddItemPopup(e);
    }

    public void AddItemPopup(InventoryItem item)
    {
        GameObject itemPopup = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/SingleItemPickupPanel"), new Vector3(), new Quaternion()) as GameObject;
        SingleItemPickupPanel newItemPickupPanel = itemPopup.GetComponent<SingleItemPickupPanel>();

        newItemPickupPanel.image.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        newItemPickupPanel.tmproText.SetText(item.itemName);

        itemPopup.transform.SetParent(content.transform);
        itemPopup.transform.SetSiblingIndex(0);
    }
}