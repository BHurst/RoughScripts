using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterAbilitiesPane : MonoBehaviour
{
    public Canvas canv;
    public static int previousHotbarSlot;

    public static void DisplayCharacterInventory()
    {
        //foreach (RootAbility knownAbility in GameWorldReferenceClass.GW_Player.availableAbilities)
        //{
        //    GameObject abilityContainer = GameObject.Instantiate(Resources.Load("Prefabs/Abilities/AbilityContainer")) as GameObject;
        //    abilityContainer.transform.SetParent(chatPaneContainer.transform, false);

        //    InventorySlot.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.itemInSlot.iStats.itemImageLocation);
        //}
    }

    void OnEnable()
    {
        DisplayCharacterInventory();
    }

    private void OnDisable()
    {
    }
}