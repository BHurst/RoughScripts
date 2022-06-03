using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityRunePane : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject FormList;
    public Image FormRuneIcon;
    public Text FormRuneRank;
    [HideInInspector]
    public FormRune ActiveFormRune;
    public GameObject CastModeList;
    public Image CastModeRuneIcon;
    public Text CastModeRuneRank;
    [HideInInspector]
    public CastModeRune ActiveCastModeRune;
    public GameObject SchoolList;
    public Image SchoolRuneIcon;
    public Text SchoolRuneRank;
    [HideInInspector]
    public SchoolRune ActiveSchoolRune;
    public GameObject EffectList;
    public Text EffectRuneIcon;
    public Text EffectRuneRank;
    public Toggle EffectTargeting;
    [HideInInspector]
    public EffectRune ActiveEffectRune;
    public Ability NewAbility;
    public GameObject PreviousAbilityList;

    public AbilityBookCreationSlot abilitySlot;

    int numOfRunes = 0;

    private void Start()
    {
        mainPanel.transform.position = transform.position;
        mainPanel.SetActive(false);
    }

    public void Show()
    {
        mainPanel.SetActive(true);
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
    }

    public void CreateAbility()
    {
        NewAbility = null;
        NewAbility = new Ability();
        NewAbility.abilityID = Guid.NewGuid();
        FormRune newForm = (FormRune)Activator.CreateInstance(ActiveFormRune.GetType());
        NewAbility.formRune = newForm;
        NewAbility.formRune.rank = int.Parse(FormRuneRank.text);
        CastModeRune newCast = (CastModeRune)Activator.CreateInstance(ActiveCastModeRune.GetType());
        NewAbility.castModeRune = newCast;
        NewAbility.castModeRune.rank = int.Parse(CastModeRuneRank.text);
        SchoolRune newSchool = (SchoolRune)Activator.CreateInstance(ActiveSchoolRune.GetType());
        NewAbility.schoolRune = newSchool;
        NewAbility.schoolRune.rank = int.Parse(SchoolRuneRank.text);
        NewAbility.effectRunes = new List<EffectRune>();
        if (ActiveEffectRune != null && ActiveEffectRune.runeName != ".")
        {
            EffectRune newEffect = (EffectRune)Activator.CreateInstance(ActiveEffectRune.GetType());
            newEffect.rank = int.Parse(EffectRuneRank.text);
            newEffect.targetSelf = EffectTargeting.isOn;
            NewAbility.effectRunes.Add(newEffect);
        }

        NewAbility.initialized = true;
        NewAbility.harmful = true;

        abilitySlot.abilityInSlot = NewAbility;
        abilitySlot.abilityInSlot.NameSelf();
        abilitySlot.SetImage(NewAbility);
        AddToKnownAbilitiesList(NewAbility);
    }

    public void AddToKnownAbilitiesList(Ability ability)
    {
        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/KnownAbility")) as GameObject;
        KnownAbilitySlot slotScript = slot.GetComponent<KnownAbilitySlot>();

        slotScript.abilityImage.SetImage(ability);
        slotScript.abilityImage.abilityInSlot = ability;
        slotScript.abilityImage.SetTooltipInfo(PlayerCharacterUnit.player);

        slot.transform.SetParent(PreviousAbilityList.transform);
    }

    public void AddSlot(List<FormRune> runeList)
    {
        foreach (FormRune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.rune = rune;
            currentRune.SetTooltipInfo();
            numOfRunes = FormList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(FormList.transform);
        }
        numOfRunes = 0;
    }

    public void AddSlot(List<SchoolRune> runeList)
    {
        foreach (SchoolRune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.rune = rune;
            currentRune.SetTooltipInfo();
            numOfRunes = SchoolList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(SchoolList.transform);
        }
        numOfRunes = 0;
    }

    public void AddSlot(List<CastModeRune> runeList)
    {
        foreach (CastModeRune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.rune = rune;
            currentRune.SetTooltipInfo();
            numOfRunes = CastModeList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(CastModeList.transform);
        }
        numOfRunes = 0;
    }

    public void AddSlot(List<EffectRune> runeList)
    {
        foreach (EffectRune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.readableName;
            slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.rune = rune;
            currentRune.SetTooltipInfo();
            numOfRunes = EffectList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(EffectList.transform);
        }
        numOfRunes = 0;
    }
}