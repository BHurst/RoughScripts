using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UITrunkNode_Serialized
{
    public bool active = false;
    public UILocusRune_Serialized LocusRuneInTrunkSlot;
    public UILocusRuneSlot_Serialized connectedSlot1;
    public UILocusRuneSlot_Serialized connectedSlot2;
    public UILocusRuneSlot_Serialized connectedSlot3;
    public UILocusRuneSlot_Serialized connectedSlot4;

    public void FillFromUnserialized(UITrunkNode uiTrunkNode)
    {
        active = uiTrunkNode.runeInTrunkSlot.active;
        LocusRuneInTrunkSlot = new UILocusRune_Serialized();
        LocusRuneInTrunkSlot.FillFromUnserialized(uiTrunkNode.runeInTrunkSlot);

        if (uiTrunkNode.connectedRune1 != null)
        {
            connectedSlot1 = new UILocusRuneSlot_Serialized();
            connectedSlot1.FillFromUnserialized(uiTrunkNode.connectedRune1);
        }
        if (uiTrunkNode.connectedRune2 != null)
        {
            connectedSlot2 = new UILocusRuneSlot_Serialized();
            connectedSlot2.FillFromUnserialized(uiTrunkNode.connectedRune2);
        }
        if (uiTrunkNode.connectedRune3 != null)
        {
            connectedSlot3 = new UILocusRuneSlot_Serialized();
            connectedSlot3.FillFromUnserialized(uiTrunkNode.connectedRune3);
        }
        if (uiTrunkNode.connectedRune4 != null)
        {
            connectedSlot4 = new UILocusRuneSlot_Serialized();
            connectedSlot4.FillFromUnserialized(uiTrunkNode.connectedRune4);
        }
    }
}