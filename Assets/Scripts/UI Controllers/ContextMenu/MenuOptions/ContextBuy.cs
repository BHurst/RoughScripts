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
        var lineItem = UIManager.main.storeSheet.sellerInventoryList.transform.GetChild(UIManager.main.contextMenu.contextIndex).GetComponent<UI_LineItem>().lineItem;
        PlayerCharacterUnit.player.charInventory.AddItem(lineItem.item);
        PlayerCharacterUnit.player.playerResources.magicDust -= lineItem.cost;
        lineItem.currentStock--;
        UIManager.main.contextMenu.HideMenu();
    }
}