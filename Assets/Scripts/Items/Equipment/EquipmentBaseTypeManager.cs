using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseTypeManager
{
    HeadEquipmentBases HeadBases = new HeadEquipmentBases();

    public List<EquipmentInventoryItem> GetAllBaseTypes()
    {
        List<EquipmentInventoryItem> baseTypes = new List<EquipmentInventoryItem>();

        baseTypes.AddRange(HeadBases.GetHeadItems());

        return baseTypes;
    }

    public EquipmentInventoryItem SelectBaseType(List<EquipmentInventoryItem> baseTypeList)
    {
        float randWholePool = 0;
        float randIncrementPool = 0;
        EquipmentInventoryItem baseType = new EquipmentInventoryItem();

        foreach (var item in baseTypeList)
        {
            randWholePool += item.dropWeight;
        }

        float randPick = Random.Range(0, randWholePool);

        foreach (var item in baseTypeList)
        {
            if (randPick <= item.dropWeight + randIncrementPool)
            {
                baseType = (EquipmentInventoryItem)item.Clone();
                baseType.fitsInSlot = item.fitsInSlot;
                baseType.locusRune = ItemFactory.CreateRandomLocusRune();
                
                break;
            }
            else
                randIncrementPool += item.dropWeight;
        }

        return baseType;
    }
}