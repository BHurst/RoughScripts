using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitUIManagerSorter : MonoBehaviour
{
    public static UnitUIManagerSorter main;
    public List<UnitUIManager> unitUIs = new List<UnitUIManager>();
    float timer = 0;

    private void Awake()
    {
        main = this;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > .1f)
        {
            List<UnitUIManager> sortedUnitUIs = unitUIs.OrderByDescending(x => x.distance).ToList();

            for (int i = 0; i < sortedUnitUIs.Count; i++)
            {
                sortedUnitUIs[i].parentPane.SetSiblingIndex(i);
            }

            timer = 0;
        }
    }
}