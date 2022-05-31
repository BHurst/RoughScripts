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
        if (!PlayerCharacterUnit.player.charInventory.UseItem(characterInventoryPane.ContextIndex))
            characterInventoryPane.RefreshIndex(characterInventoryPane.ContextIndex);
        characterInventoryPane.CloseContext();
    }
}