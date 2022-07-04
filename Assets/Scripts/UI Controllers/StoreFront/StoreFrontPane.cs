using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreFrontPane : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject storeSide;
    public Transform storeInventoryList;
    public GameObject playerSide;
    public Transform playerInventoryList;
    public TextMeshProUGUI dust;

    void Start()
    {
        mainPanel.transform.position = transform.position;
        mainPanel.SetActive(false);
    }

    public void Show(StoreFrontData storeFrontData)
    {
        mainPanel.SetActive(true);
        dust.SetText(PlayerCharacterUnit.player.playerResources.magicDust.ToString() + " Magic Dust");
        if (storeFrontData.hasInventoryToSell)
        {
            storeSide.SetActive(true);
            DisplayBuyWindow(storeFrontData);
        }
        else
            storeSide.SetActive(false);
        if (storeFrontData.allowBeingSoldTo)
        {
            playerSide.SetActive(true);
            DisplaySellWindow();
        }
        else
            playerSide.SetActive(false);
    }

    public void Hide()
    {
        foreach (Transform item in storeInventoryList)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in playerInventoryList)
        {
            Destroy(item.gameObject);
        }
        mainPanel.SetActive(false);
    }

    public void RemovePlayerLineItem(int index)
    {
        if (playerInventoryList.childCount > 0)
            for (int i = index; i < playerInventoryList.childCount; i++)
            {
                playerInventoryList.GetChild(i).GetComponent<UI_LineItem>().inventoryIndex--;
            }
        Destroy(playerInventoryList.GetChild(index).gameObject);
    }

    public void BuyItem(LineItem lineItem)
    {
        if (PlayerCharacterUnit.player.playerResources.CostCheck(lineItem.cost))
        {
            PlayerCharacterUnit.player.charInventory.AddItem(lineItem.item);
            PlayerCharacterUnit.player.playerResources.magicDust -= lineItem.cost;
            dust.SetText(PlayerCharacterUnit.player.playerResources.magicDust.ToString() + " Magic Dust");
            lineItem.currentStock--;
            storeInventoryList.GetChild(UIManager.main.contextMenu.contextIndex).GetComponent<UI_LineItem>().SetStock();
            UIManager.main.contextMenu.HideMenu();
        }
        else
        {
            ErrorScript.DisplayError("Not enough dust");
            UIManager.main.contextMenu.HideMenu();
        }
    }

    public void DisplaySellWindow()
    {
        int numOfItems = 0;
        foreach (InventoryItem item in PlayerCharacterUnit.player.charInventory.Inventory)
        {
            GameObject newObj = Instantiate(Resources.Load("Prefabs/UIComponents/StoreFront/StoreLineItemSlot")) as GameObject;

            UI_LineItem slot = newObj.GetComponent<UI_LineItem>();
            slot.lineItem = new LineItem() { item = item, cost = 5, currentStock = 1, maxStock = 1 };
            slot.player = true;
            slot.inventoryIndex = numOfItems;
            slot.DefaultCreation();

            newObj.transform.SetParent(playerInventoryList.transform);
            numOfItems++;
        }
    }

    public void DisplayBuyWindow(StoreFrontData storeFrontData)
    {
        int numOfItems = 0;
        foreach (LineItem lineItem in storeFrontData.lineItems)
        {
            GameObject newObj = Instantiate(Resources.Load("Prefabs/UIComponents/StoreFront/StoreLineItemSlot")) as GameObject;

            UI_LineItem slot = newObj.GetComponent<UI_LineItem>();
            slot.player = false;
            slot.lineItem = lineItem;
            slot.inventoryIndex = numOfItems;
            slot.DefaultCreation();

            newObj.transform.SetParent(storeInventoryList.transform);
            numOfItems++;
        }
    }
}