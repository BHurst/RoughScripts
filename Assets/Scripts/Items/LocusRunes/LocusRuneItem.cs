using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRuneItem : InventoryItem
{
    public LocusRune LocusRune;

    public LocusRuneItem()
    {
        LocusRune = LocusRune.RandomRune();
        itemID = Random.Range(0, 10000);
    }
}