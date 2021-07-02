using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static List<WorldItem> AllWorldItems = new List<WorldItem>();
    public static List<GameObject> InactiveDamageTextList = new List<GameObject>();
    public Transform DamageTextContainer;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
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
        var foundD = PopupTextManager.damageTextInfos.FirstOrDefault(x => x.textObject == text.GetComponent<TextMeshProUGUI>());
        if (foundD != null)
            PopupTextManager.damageTextInfos.Remove(foundD);

        var foundH = PopupTextManager.healingTextInfos.FirstOrDefault(x => x.textObject == text.GetComponent<TextMeshProUGUI>());
        if (foundH != null)
            PopupTextManager.healingTextInfos.Remove(foundH);

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