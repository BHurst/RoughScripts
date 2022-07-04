using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextBuy : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.main.storeSheet.BuyItem(UIManager.main.storeSheet.storeInventoryList.transform.GetChild(UIManager.main.contextMenu.contextIndex).GetComponent<UI_LineItem>().lineItem);
    }
}