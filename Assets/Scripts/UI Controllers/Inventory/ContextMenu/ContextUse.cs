using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextUse : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameWorldReferenceClass.GW_Player.charInventory.UseItem(characterInventoryPane.ContextIndex))
            characterInventoryPane.RefreshIndex(characterInventoryPane.ContextIndex);
        characterInventoryPane.CloseContext();
    }
}