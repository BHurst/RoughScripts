using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityRunePane : MonoBehaviour
{
    public GameObject FormList;
    public GameObject CastModeList;
    public GameObject SchoolList;

    public GameObject BuffList;
    public GameObject DebuffList;
    public GameObject HarmList;
    public GameObject HealList;

    int numOfRunes = 0;

    public void AddSlot(List<Rune> runeList)
    {
        foreach (Rune rune in runeList)
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/Runes/RuneSlot")) as GameObject;
            
            slot.transform.Find("RuneName").GetComponent<Text>().text = rune.ToString();
            if (rune.runeImageLocation != "None")
                slot.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(rune.runeImageLocation);

            if (rune is FormRune formRune)
            {
                numOfRunes = FormList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(FormList.transform);
            }
            else if (rune is CastModeRune modeRune)
            {
                numOfRunes = CastModeList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(CastModeList.transform);
            }
            else if (rune is SchoolRune schoolRune)
            {
                numOfRunes = SchoolList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(SchoolList.transform);
            }
            else if (rune is Buff_Rune buff_Rune)
            {
                numOfRunes = BuffList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(BuffList.transform);
            }
            else if (rune is Debuff_Rune debuff_Rune)
            {
                numOfRunes = DebuffList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(DebuffList.transform);
            }
            else if (rune is Harm_Rune harm_Rune)
            {
                numOfRunes = HarmList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(HarmList.transform);
            }
            else if (rune is Heal_Rune heal_Rune)
            {
                numOfRunes = HealList.transform.childCount;
                slot.GetComponent<SingleRuneSlot>().runeIndex = numOfRunes;
                slot.transform.SetParent(HealList.transform);
            }
        }
        numOfRunes = 0;
    }

}