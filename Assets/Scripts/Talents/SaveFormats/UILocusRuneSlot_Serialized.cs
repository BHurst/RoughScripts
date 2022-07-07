using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UILocusRuneSlot_Serialized
{
    public UILocusRuneSlot_Serialized previousSlot;
    public UILocusRune_Serialized locusRuneInSlot;
    public bool available = false;
    public UILocusRuneSlot_Serialized connectedRune1;
    public UILocusRuneSlot_Serialized connectedRune2;
    public UILocusRuneSlot_Serialized connectedRune3;
    public UILocusRuneSlot_Serialized connectedRune4;

    public void FillFromUnserialized(UILocusRuneSlot uiLocusRuneSlot)
    {
        if(uiLocusRuneSlot != null)
        {
            if (uiLocusRuneSlot.previousSlot != null)
            {
                previousSlot = new UILocusRuneSlot_Serialized();
                previousSlot.FillFromUnserialized(uiLocusRuneSlot.previousSlot);
            }
            if (uiLocusRuneSlot.locusRuneInSlot != null)
            {
                locusRuneInSlot = new UILocusRune_Serialized();
                locusRuneInSlot.FillFromUnserialized(uiLocusRuneSlot.locusRuneInSlot);
            }
            available = uiLocusRuneSlot.available;
            if (uiLocusRuneSlot.connectedRune1 != null)
            {
                connectedRune1 = new UILocusRuneSlot_Serialized();
                connectedRune1.FillFromUnserialized(uiLocusRuneSlot.connectedRune1);
            }
            if (uiLocusRuneSlot.connectedRune2 != null)
            {
                connectedRune2 = new UILocusRuneSlot_Serialized();
                connectedRune2.FillFromUnserialized(uiLocusRuneSlot.connectedRune2);
            }
            if (uiLocusRuneSlot.connectedRune3 != null)
            {
                connectedRune3 = new UILocusRuneSlot_Serialized();
                connectedRune3.FillFromUnserialized(uiLocusRuneSlot.connectedRune3);
            }
            if (uiLocusRuneSlot.connectedRune4 != null)
            {
                connectedRune4 = new UILocusRuneSlot_Serialized();
                connectedRune4.FillFromUnserialized(uiLocusRuneSlot.connectedRune4);
            }
        }
    }
}