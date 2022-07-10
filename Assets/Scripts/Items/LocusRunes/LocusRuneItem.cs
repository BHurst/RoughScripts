using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRuneItem : InventoryItem
{
    public LocusRune locusRune;

    public LocusRuneItem()
    {
        locusRune = LocusRune.RandomRune();
        itemID = Random.Range(0, 10000);
    }
}