using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContextMenu : MonoBehaviour
{
    public GameObject contextList;

    public ContextBuy contextBuy;
    public ContextEquip contextEquip;
    public ContextSell contextSell;
    public ContextSetQuick contextSetQuick;
    public ContextUnequip contextUnequip;
    public ContextUse contextUse;
    public ContextDrop contextDrop;
    
    public ContextCloser contextCloser;

    public GameObject contextClicked;
    public int contextIndex;

    void ShowMenu()
    {
        contextList.transform.position = Mouse.current.position.ReadValue();
        contextList.gameObject.SetActive(true);
        contextCloser.gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        foreach(Transform option in contextList.transform)
            option.gameObject.SetActive(false);

        contextList.gameObject.SetActive(false);
        contextCloser.gameObject.SetActive(false);
        contextClicked = null;
        contextIndex = -1;
    }

    public void OpenInventoryEquipmentMenu(EquipmentInventoryItem equipmentInventoryItem)
    {
        contextEquip.gameObject.SetActive(true);
        contextDrop.gameObject.SetActive(true);

        ShowMenu();
    }

    public void OpenDollEquipmentMenu(EquipmentInventoryItem equipmentInventoryItem)
    {
        contextUnequip.gameObject.SetActive(true);

        ShowMenu();
    }

    public void OpenInventoryItemMenu(InventoryItem inventoryItem)
    {
        if (inventoryItem.usable)
        {
            contextUse.gameObject.SetActive(true);
            contextSetQuick.gameObject.SetActive(true);
        }
        contextDrop.gameObject.SetActive(true);
        ShowMenu();
    }

    public void OpenSellerStoreItemMenu(InventoryItem inventoryItem)
    {
        contextBuy.gameObject.SetActive(true);
        ShowMenu();
    }

    public void OpenPlayerStoreItemMenu(InventoryItem inventoryItem)
    {
        contextSell.gameObject.SetActive(true);
        ShowMenu();
    }
}