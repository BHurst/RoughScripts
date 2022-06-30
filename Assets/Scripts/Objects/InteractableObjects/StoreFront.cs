using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFront : InteractableObject
{
    public StoreFrontData storeFrontData = new StoreFrontData();
    bool storeOpen = false;

    private void Start()
    {
        tooltipInfo.bodyContent = "Open store";
    }

    public override void Use()
    {
        storeOpen = !storeOpen;

        UIManager.main.OpenStoreFront(storeFrontData);
    }
}