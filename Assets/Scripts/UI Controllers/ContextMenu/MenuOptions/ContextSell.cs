using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextSell : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var lineItem = UIManager.main.storeSheet.playerInventoryList.transform.GetChild(UIManager.main.contextMenu.contextIndex).GetComponent<UI_LineItem>();
        PlayerCharacterUnit.player.charInventory.RemoveItem(lineItem.lineItem.item);
        PlayerCharacterUnit.player.playerResources.magicDust += lineItem.lineItem.cost;
        UIManager.main.storeSheet.dust.SetText(PlayerCharacterUnit.player.playerResources.magicDust.ToString() + " Magic Dust");
        UIManager.main.storeSheet.RemovePlayerLineItem(lineItem.inventoryIndex);
        UIManager.main.contextMenu.HideMenu();
    }
}