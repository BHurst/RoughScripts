using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityRunePane : MonoBehaviour
{
    public GameObject FormList;
    public GameObject FormRuneIcon;
    public GameObject CastModeList;
    public GameObject CastModeRuneIcon;
    public GameObject SchoolList;
    public GameObject SchoolRuneIcon;

    public GameObject BuffList;
    public GameObject BuffRuneIcon;
    public GameObject DebuffList;
    public GameObject DebuffRuneIcon;
    public GameObject HarmList;
    public GameObject HarmRuneIcon;
    public GameObject HealList;
    public GameObject HealRuneIcon;

    int numOfRunes = 0;


    public void AddSlot(List<FormRune> runeList)
    {
        foreach (Rune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            if (rune.runeImageLocation != "None")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.runeId = rune.runeId;

            numOfRunes = FormList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(FormList.transform);
        }
        numOfRunes = 0;
    }

    public void AddSlot(List<SchoolRune> runeList)
    {
        foreach (Rune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            if (rune.runeImageLocation != "None")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.runeId = rune.runeId;

            numOfRunes = SchoolList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(SchoolList.transform);
        }
        numOfRunes = 0;
    }

    public void AddSlot(List<CastModeRune> runeList)
    {
        foreach (Rune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;

            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.runeName;
            if (rune.runeImageLocation != "None")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            SingleRuneSlot currentRune = slot.GetComponent<SingleRuneSlot>();
            currentRune.runeId = rune.runeId;

            numOfRunes = CastModeList.transform.childCount;
            currentRune.runeIndex = numOfRunes;
            slot.transform.SetParent(CastModeList.transform);
        }
        numOfRunes = 0;
    }

}