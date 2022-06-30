using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LineItem : MonoBehaviour, IPointerClickHandler
{
    public StoreFrontPane storePane;
    public int inventoryIndex;
    public LineItem lineItem;
    public GameObject soldOutImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStack;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI itemStock;
    public Image itemImage;
    public bool player = false;

    private void Start()
    {
        storePane = GameObject.Find("StoreFrontCanvas").GetComponent<StoreFrontPane>();
    }

    public void DefaultCreation()
    {
        SetStack();
        SetName();
        SetImage();
        SetStock();
        SetCost();
    }

    public void SetStack()
    {
        if (lineItem.item.stackable)
            itemStack.SetText(lineItem.item.currentStackSize.ToString() + "/" + lineItem.item.maxStackSize.ToString());
        else if (lineItem.item.usable)
            itemStack.SetText(((ConsumableInventoryItem)lineItem.item).currentUses.ToString() + "/" + ((ConsumableInventoryItem)lineItem.item).maxUses.ToString() + " Uses");
        else
            itemStack.SetText("");
    }

    public void SetCost()
    {
        itemCost.SetText(lineItem.cost.ToString());
    }

    public void SetStock()
    {
        if(lineItem.currentStock > 0)
        {
            if (lineItem.maxStock > 1)
            {
                itemStock.SetText(lineItem.currentStock.ToString() + "/" + lineItem.maxStock.ToString());
            }
        }
        else
        {
            soldOutImage.SetActive(true);
        }
    }

    public void SetName()
    {
        itemName.SetText(lineItem.item.itemName);
    }

    public void SetImage()
    {
        itemImage.sprite = Resources.Load<Sprite>(lineItem.item.itemImageLocation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //storePane.DisplayItemInfo(lineItem.item);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (lineItem.currentStock > 0)
            {
                UIManager.main.contextMenu.contextIndex = inventoryIndex;
                if (!player)
                    UIManager.main.contextMenu.OpenSellerStoreItemMenu(lineItem.item);
                else
                    UIManager.main.contextMenu.OpenPlayerStoreItemMenu(lineItem.item);
            }
        }
    }
}