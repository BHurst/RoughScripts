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
}