using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextUse : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!PlayerCharacterUnit.player.charInventory.UseItem(UIManager.main.contextMenu.contextIndex))
            characterInventoryPane.RefreshIndex(UIManager.main.contextMenu.contextIndex);
        UIManager.main.contextMenu.HideMenu();
    }
}