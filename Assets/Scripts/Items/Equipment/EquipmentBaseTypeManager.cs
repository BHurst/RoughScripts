using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseTypeManager
{
    ArmEquipmentBases ArmBases = new ArmEquipmentBases();
    BackEquipmentBases BackBases = new BackEquipmentBases();
    ChestEquipmentBases ChestBases = new ChestEquipmentBases();
    FootEquipmentBases FootBases = new FootEquipmentBases();
    HandEquipmentBases HandBases = new HandEquipmentBases();
    HeadEquipmentBases HeadBases = new HeadEquipmentBases();
    LegEquipmentBases LegBases = new LegEquipmentBases();
    NeckEquipmentBases NeckBases = new NeckEquipmentBases();
    ShoulderEquipmentBases ShoulderBases = new ShoulderEquipmentBases();
    WaistEquipmentBases WaistBases = new WaistEquipmentBases();

    public List<EquipmentInventoryItem> GetAllBaseTypes()
    {
        List<EquipmentInventoryItem> baseTypes = new List<EquipmentInventoryItem>();

        baseTypes.AddRange(ArmBases.GetArmItems());
        baseTypes.AddRange(BackBases.GetBackItems());
        baseTypes.AddRange(ChestBases.GetChestItems());
        baseTypes.AddRange(FootBases.GetFootItems());
        baseTypes.AddRange(HandBases.GetHandItems());
        baseTypes.AddRange(HeadBases.GetHeadItems());
        baseTypes.AddRange(LegBases.GetLegItems());
        baseTypes.AddRange(NeckBases.GetNeckItems());
        baseTypes.AddRange(ShoulderBases.GetShoulderItems());
        baseTypes.AddRange(WaistBases.GetWaistItems());

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