using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterInventoryPane : MonoBehaviour
{
    public GameObject InventoryList;
    public GameObject EquipmentSlot;
    public GameObject itemDescriptionP;
    public Canvas canv;
    public bool initialLoad;

    public Image itemImage;
    public Text itemDescription;
    public Text itemInfo;

    public Text strengthP;
    public Text agilityP;
    public Text intellectP;
    public Text staminaP;
    public Text wisdomP;
    public Text willpowerP;
    public Text skillP;

    public Text moneyP;

    int numOfItems = 0;

    public void Start()
    {

    }

    public void DisplayItemInfo(InventoryItem item)
    {
        itemDescriptionP.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>(item.itemImageLocation);
        itemDescription.text = item.itemDescription;
    }

    public void DisplayCharacterInventory()
    {
        if (InventoryList.transform.childCount > 0)
            foreach (Transform kid in InventoryList.transform)
                Destroy(kid.gameObject);

        foreach (InventoryItem item in GameWorldReferenceClass.GW_Player.charInventory.Inventory)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

            slot.GetComponent<SingleInventorySlotScript>().inventoryIndex = numOfItems;
            slot.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
            if (item.itemImageLocation != "Items/")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.itemImageLocation);

            //if(item.slotEquippedIn != "None")
            //    slot.GetComponent<SingleInventorySlotScript>().backImage.GetComponent<Outline>().enabled = true;
            //else
            //    slot.GetComponent<SingleInventorySlotScript>().backImage.GetComponent<Outline>().enabled = false;

            if (item.stackable)
                slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentStackSize.ToString() + "/" + item.maxStackSize.ToString();
            else if (item.usable)
                slot.transform.Find("StackCount").GetComponent<Text>().text = item.currentCharges.ToString() + "/" + item.maxCharges.ToString() + " Charges";
            else
                slot.transform.Find("StackCount").GetComponent<Text>().text = "";

            slot.transform.SetParent(InventoryList.transform);
            numOfItems++;
        }
        numOfItems = 0;
    }

    public void DisplayDollSlots(RootUnit unit)
    {
        //EquipmentSlot = GameObject.Find(slotName);
        //if (equipment.hasItem)
        //{
        //    EquipmentSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>(equipment.itemInSlot.iStats.itemImageLocation);
        //}
        //else
        //{
        //    EquipmentSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/Images/NoItemBackground");
        //}
    }


    void OnEnable()
    {
        if (initialLoad)
        {
            DisplayCharacterInventory();
        }
        else
            initialLoad = true;
    }
}