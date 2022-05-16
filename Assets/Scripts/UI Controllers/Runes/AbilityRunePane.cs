using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityRunePane : MonoBehaviour
{
    public CharacterPanelScripts mainPanel;
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

    public AbilityBookCreationSlot abilitySlot;

    int numOfRunes = 0;

    public void CreateAbility()
    {
        NewAbility = null;
        NewAbility = new Ability();
        NewAbility.abilityID = Guid.NewGuid();
        FormRune newForm = (FormRune)Activator.CreateInstance(ActiveFormRune.GetType());
        NewAbility.aFormRune = newForm;
        NewAbility.aFormRune.rank = int.Parse(FormRuneRank.text);
        CastModeRune newCast = (CastModeRune)Activator.CreateInstance(ActiveCastModeRune.GetType());
        NewAbility.aCastModeRune = newCast;
        NewAbility.aCastModeRune.rank = int.Parse(CastModeRuneRank.text);
        SchoolRune newSchool = (SchoolRune)Activator.CreateInstance(ActiveSchoolRune.GetType());
        NewAbility.aSchoolRune = newSchool;
        NewAbility.aSchoolRune.rank = int.Parse(SchoolRuneRank.text);
        NewAbility.aEffectRunes = new List<EffectRune>();
        if (ActiveEffectRune != null && ActiveEffectRune.runeName != ".")
        {
            EffectRune newEffect = (EffectRune)Activator.CreateInstance(ActiveEffectRune.GetType());
            newEffect.rank = int.Parse(EffectRuneRank.text);
            newEffect.targetSelf = EffectTargeting.isOn;
            NewAbility.aEffectRunes.Add(newEffect);
        }

        NewAbility.initialized = true;
        NewAbility.harmful = true;

        abilitySlot.abilityInSlot = NewAbility;
        abilitySlot.abilityInSlot.NameSelf();
        abilitySlot.SetImage(NewAbility);
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

            numOfRunes = EffectList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(EffectList.transform);
        }
        numOfRunes = 0;
    }

    private void OnDisable()
    {
        mainPanel.heldAbility.ability = null;
        mainPanel.heldAbility.ClearImage();
        mainPanel.heldAbility.gameObject.SetActive(false);
        abilitySlot.abilityInSlot = null;
    }
}