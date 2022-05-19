using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatPane : MonoBehaviour
{
    public GameObject StatList;

    public void OnEnable()
    {
        foreach (Transform kid in StatList.transform)
            Destroy(kid.gameObject);

        GameObject healthSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        healthSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Life";
        healthSlot.transform.SetParent(StatList.transform);
        healthSlot.transform.Find("Value").GetComponent<Text>().text = GameWorldReferenceClass.GW_Player.totalStats.Health_Max.ToString();

        GameObject healthRegenSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        healthRegenSlot.transform.Find("Stat").GetComponent<Text>().text = "Life Regeneration";
        healthRegenSlot.transform.SetParent(StatList.transform);
        healthRegenSlot.transform.Find("Value").GetComponent<Text>().text = (Mathf.Round(GameWorldReferenceClass.GW_Player.totalStats.Health_Regeneration * 100f) / 100f).ToString() + "/sec";

        GameObject manaSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        manaSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Mana";
        manaSlot.transform.SetParent(StatList.transform);
        manaSlot.transform.Find("Value").GetComponent<Text>().text = GameWorldReferenceClass.GW_Player.totalStats.Mana_Max.ToString();

        GameObject manaRegenSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        manaRegenSlot.transform.Find("Stat").GetComponent<Text>().text = "Mana Regeneration";
        manaRegenSlot.transform.SetParent(StatList.transform);
        manaRegenSlot.transform.Find("Value").GetComponent<Text>().text = (Mathf.Round(GameWorldReferenceClass.GW_Player.totalStats.Mana_Regeneration * 100f) / 100f).ToString() + "/sec";

        GameObject speedSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        speedSlot.transform.Find("Stat").GetComponent<Text>().text = "Movement Speed";
        speedSlot.transform.SetParent(StatList.transform);
        speedSlot.transform.Find("Value").GetComponent<Text>().text = GameWorldReferenceClass.GW_Player.totalStats.Movement.value.ToString();

        foreach (FieldInfo field in typeof(UnitStats).GetFields())
        {
            string cleanedName = field.Name.Replace("_", " ");
            UnitStat stat;
            if(field.GetValue(GameWorldReferenceClass.GW_Player.totalStats) is UnitStat)
            {
                stat = (UnitStat)field.GetValue(GameWorldReferenceClass.GW_Player.totalStats);

                if (cleanedName.Contains("Flat") && stat.value != stat.defaultValue)
                {
                    GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                    slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                    slot.transform.SetParent(StatList.transform);
                    slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + stat.value.ToString();
                }
                else if ((cleanedName.Contains("AddPercent") && stat.value != stat.defaultValue))
                {
                    GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                    slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                    slot.transform.SetParent(StatList.transform);
                    slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round(stat.value * 100).ToString() + "%";
                }
                else if ((cleanedName.Contains("MultiplyPercent") && stat.value != stat.defaultValue))
                {
                    GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                    slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                    slot.transform.SetParent(StatList.transform);
                    slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round((stat.value - 1) * 100).ToString() + "%";
                }
                else if (stat.value != stat.defaultValue && stat.displayOnStatScreen)
                {
                    GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                    slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                    slot.transform.SetParent(StatList.transform);
                    slot.transform.Find("Value").GetComponent<Text>().text = stat.value.ToString();
                }
                else
                {
                    //If the conditions aren't satisfied, it shouldn't be shown at all.
                }
            } 
        }
    }
}