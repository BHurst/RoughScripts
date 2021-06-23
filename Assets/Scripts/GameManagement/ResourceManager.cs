using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static List<WorldItem> AllWorldItems = new List<WorldItem>();
    public static List<GameObject> InactiveDamageTextList = new List<GameObject>();
    public Transform DamageTextContainer;

    private void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            GameObject newDamageText = GameObject.Instantiate(Resources.Load("Prefabs/UIComponents/FloatingNumberCanvas")) as GameObject;
            newDamageText.transform.SetParent(DamageTextContainer);
            newDamageText.SetActive(false);
            InactiveDamageTextList.Add(newDamageText);
        }
    }

    public static void HideItem(WorldItem item)
    {
        if (AllWorldItems.Count >= 50)
        {
            Destroy(item);
        }
        else
        {
            item.gameObject.SetActive(false);
            item.Revert();
            AllWorldItems.Add(item);
        }
    }

    public static WorldItem RestoreItem()
    {
        WorldItem temp = AllWorldItems[0];
        AllWorldItems.RemoveAt(0);
        return temp;
    }

    public static void HideDamageText(GameObject text)
    {
        text.gameObject.SetActive(false);
        InactiveDamageTextList.Add(text);
    }

    public static GameObject RestoreDamageText()
    {
        GameObject temp = InactiveDamageTextList[0];
        temp.SetActive(true);
        InactiveDamageTextList.RemoveAt(0);
        return temp;
    }
}