using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFrontPane : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject sellerSide;
    public GameObject sellerInventoryList;
    public GameObject playerSide;
    public GameObject playerInventoryList;

    void Start()
    {
        mainPanel.transform.position = transform.position;
        mainPanel.SetActive(false);
    }

    public void Show(StoreFrontData storeFrontData)
    {
        mainPanel.SetActive(true);
        if (storeFrontData.hasInventoryToSell)
        {
            sellerSide.SetActive(true);
            DisplayBuyWindow(storeFrontData);
        }
        else
            sellerSide.SetActive(false);
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
        foreach (Transform item in sellerInventoryList.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in playerInventoryList.transform)
        {
            Destroy(item.gameObject);
        }
        mainPanel.SetActive(false);
    }

    public void DisplaySellWindow()
    {
        int numOfItems = playerInventoryList.transform.childCount;
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
        numOfItems = 0;
    }

    public void DisplayBuyWindow(StoreFrontData storeFrontData)
    {
        int numOfItems = sellerInventoryList.transform.childCount;
        foreach (LineItem lineItem in storeFrontData.lineItems)
        {
            GameObject newObj = Instantiate(Resources.Load("Prefabs/UIComponents/StoreFront/StoreLineItemSlot")) as GameObject;

            UI_LineItem slot = newObj.GetComponent<UI_LineItem>();
            slot.player = false;
            slot.lineItem = lineItem;
            slot.inventoryIndex = numOfItems;
            slot.DefaultCreation();

            newObj.transform.SetParent(sellerInventoryList.transform);
            numOfItems++;
        }
        numOfItems = 0;
    }
}