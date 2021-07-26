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

        foreach (FieldInfo field in typeof(UnitStats).GetFields())
        {
            GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;

            string cleanedName = field.Name.Replace("_", " ");
            slot.transform.Find("Stat").GetComponent<Text>().text = cleanedName;

            float cleanedValue = (float)field.GetValue(GameWorldReferenceClass.GW_Player.totalStats);
            if (cleanedName.Contains("Flat"))
                slot.transform.Find("Value").GetComponent<Text>().text = (cleanedValue < 0 ? "-" : "+") + cleanedValue.ToString();
            else if (cleanedName.Contains("Percent"))
                slot.transform.Find("Value").GetComponent<Text>().text = (cleanedValue * 100).ToString() + "%";
            else
                slot.transform.Find("Value").GetComponent<Text>().text = cleanedValue.ToString();


            slot.transform.SetParent(StatList.transform);
        }
    }
}