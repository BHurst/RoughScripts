using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterInventoryPane : MonoBehaviour
{
    static GameObject InventoryList;
    public GameObject inventoryL;
    public GameObject EquipmentSlot;
    static GameObject ItemDescriptionPanel;
    public GameObject itemDescriptionP;
    bool isInventoryOpen = false;
    public Canvas canv;
    public bool initialLoad;

    static Image ItemImage;
    public Image itemImage;
    static Text ItemDescription;
    public Text itemDescription;
    static Text ItemInfo;
    public Text itemInfo;

    static Text StrengthPanel;
    public Text strengthP;
    static Text AgilityPanel;
    public Text agilityP;
    static Text IntellectPanel;
    public Text intellectP;
    static Text StaminaPanel;
    public Text staminaP;
    static Text WisdomPanel;
    public Text wisdomP;
    static Text WillpowerPanel;
    public Text willpowerP;
    static Text SkillPanel;
    public Text skillP;

    static Text MoneyPanel;
    public Text moneyP;

    public void Start()
    {
        StrengthPanel = strengthP;
        AgilityPanel = agilityP;
        IntellectPanel = intellectP;
        StaminaPanel = staminaP;
        WisdomPanel = wisdomP;
        WillpowerPanel = willpowerP;
        SkillPanel = skillP;

        MoneyPanel = moneyP;

        InventoryList = inventoryL;

        ItemDescriptionPanel = itemDescriptionP;

        ItemImage = itemImage;
        ItemDescription = itemDescription;
        ItemInfo = itemInfo;
    }

    public static void DisplayItemInfo(InventoryItem item)
    {
        ItemDescriptionPanel.SetActive(true);
        ItemImage.sprite = Resources.Load<Sprite>(item.iStats.itemImageLocation);
        ItemDescription.text = item.iStats.itemDescription;
        ItemInfo.text = item.iStats.LongHandStats();
    }

    public static void DisplayCharacterInventory()
    {
        foreach (Transform kid in InventoryList.transform)
            Destroy(kid.gameObject);

        foreach (InventorySlot item in GameWorldReferenceClass.GW_Player.charInventory.Inventory)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Inventory/InventorySlot")) as GameObject;

            slot.GetComponent<SingleInventorySlotScript>().itemInSlot = item.itemInSlot;
            slot.transform.Find("ItemName").GetComponent<Text>().text = item.itemInSlot.iStats.itemName;

            if(item.itemInSlot.slotEquippedIn != "None")
                slot.GetComponent<SingleInventorySlotScript>().backImage.GetComponent<Outline>().enabled = true;
            else
                slot.GetComponent<SingleInventorySlotScript>().backImage.GetComponent<Outline>().enabled = false;

            if (item.itemInSlot.iStats.stackCount > 1)
                slot.transform.Find("StackCount").GetComponent<Text>().text = item.itemInSlot.iStats.stackCount.ToString() + "/" + item.itemInSlot.iStats.stackSize.ToString();
            else
                slot.transform.Find("StackCount").GetComponent<Text>().text = "";

            slot.transform.SetParent(InventoryList.transform);
        }

        StrengthPanel.text = GameWorldReferenceClass.GW_Player.attributes.Strength.ToString();
        AgilityPanel.text = GameWorldReferenceClass.GW_Player.attributes.Agility.ToString();
        IntellectPanel.text = GameWorldReferenceClass.GW_Player.attributes.Intellect.ToString();
        StaminaPanel.text = GameWorldReferenceClass.GW_Player.attributes.Stamina.ToString();
        WisdomPanel.text = GameWorldReferenceClass.GW_Player.attributes.Wisdom.ToString();
        WillpowerPanel.text = GameWorldReferenceClass.GW_Player.attributes.Willpower.ToString();
        SkillPanel.text = GameWorldReferenceClass.GW_Player.attributes.Skill.ToString();

        MoneyPanel.text = "Money is: " + GameWorldReferenceClass.PartyMoney.ToString();
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
            isInventoryOpen = true;
        }
        else
            initialLoad = true;
    }

    private void OnDisable()
    {
        isInventoryOpen = false;
    }
}