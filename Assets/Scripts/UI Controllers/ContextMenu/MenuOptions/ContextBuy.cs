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
        var lineItem = UIManager.main.storeSheet.storeInventoryList.transform.GetChild(UIManager.main.contextMenu.contextIndex).GetComponent<UI_LineItem>().lineItem;
        PlayerCharacterUnit.player.charInventory.AddItem(lineItem.item);
        PlayerCharacterUnit.player.playerResources.magicDust -= lineItem.cost;
        UIManager.main.storeSheet.dust.SetText(PlayerCharacterUnit.player.playerResources.magicDust.ToString() + " Magic Dust");
        lineItem.currentStock--;
        UIManager.main.contextMenu.HideMenu();
    }
}