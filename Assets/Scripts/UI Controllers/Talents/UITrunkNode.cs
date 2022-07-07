using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrunkNode : MonoBehaviour
{
    public UILocusRune runeInTrunkSlot;
    public TrunkPresetBase trunkPreset;
    Image background;
    public Talent_SelectLocusRunePane SelectLocusRunePane;
    public CharacterTalentsPane characterTalents;
    public UITrunkNode previousSlot;
    public Transform ChildSlots;
    public UILocusRuneSlot connectedRune1 = null;
    public UILocusRuneSlot connectedRune2 = null;
    public UILocusRuneSlot connectedRune3 = null;
    public UILocusRuneSlot connectedRune4 = null;
    bool loaded;

    void OnDrawGizmosSelected()
    {
        if (connectedRune1 != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, connectedRune1.transform.position);
        }
        if (connectedRune2 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, connectedRune2.transform.position);
        }
        if (connectedRune3 != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, connectedRune3.transform.position);
        }
        if (connectedRune4 != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, connectedRune4.transform.position);
        }
    }

    private void Start()
    {
        StartCheck();
    }

    public void StartCheck()
    {
        if (loaded == false)
        {
            runeInTrunkSlot.SetReferences();
            if (characterTalents == null)
                characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
            if (SelectLocusRunePane == null)
                SelectLocusRunePane = GameObject.Find("Talent_SelectLocusRunePane").GetComponent<Talent_SelectLocusRunePane>();
            if (ChildSlots == null)
                ChildSlots = transform.Find("ChildSlots").transform;
            if (background == null)
                background = GetComponent<Image>();

            if (ChildSlots.childCount > 0)
            {
                var temp1 = ChildSlots.GetChild(0);
                if (temp1 != null)
                    connectedRune1 = temp1.GetComponent<UILocusRuneSlot>();
                if (ChildSlots.childCount > 1)
                {
                    var temp2 = ChildSlots.GetChild(1);
                    if (temp2 != null)
                        connectedRune2 = temp2.GetComponent<UILocusRuneSlot>();
                    if (ChildSlots.childCount > 2)
                    {
                        var temp3 = ChildSlots.GetChild(2);
                        if (temp3 != null)
                            connectedRune3 = temp3.GetComponent<UILocusRuneSlot>();
                        if (ChildSlots.childCount > 3)
                        {
                            var temp4 = ChildSlots.GetChild(3);
                            if (temp4 != null)
                                connectedRune4 = temp4.GetComponent<UILocusRuneSlot>();
                        }
                    }
                }
            }
            loaded = true;
        }
    }

    public void SetUnavailable()
    {
        StartCheck();
        background.color = Color.black;
        runeInTrunkSlot.active = false;
        if (connectedRune1 != null)
            connectedRune1.SetUnavailable();
        if (connectedRune2 != null)
            connectedRune2.SetUnavailable();
        if (connectedRune3 != null)
            connectedRune3.SetUnavailable();
        if (connectedRune4 != null)
            connectedRune4.SetUnavailable();
    }

    public void SetAvailable()
    {
        StartCheck();
        background.color = Color.white;
        runeInTrunkSlot.active = true;
        if (connectedRune1 != null)
            connectedRune1.SetAvailable();
        if (connectedRune2 != null)
            connectedRune2.SetAvailable();
        if (connectedRune3 != null)
            connectedRune3.SetAvailable();
        if (connectedRune4 != null)
            connectedRune4.SetAvailable();
    }

    public void LoadPreset()
    {
        StartCheck();
        runeInTrunkSlot.SetRune(trunkPreset.Preset());
    }

    public void FillFromSerialized(UITrunkNode_Serialized uiTrunkNode_Serialized)
    {
        runeInTrunkSlot.active = uiTrunkNode_Serialized.active;
        runeInTrunkSlot.FillFromSerialized(uiTrunkNode_Serialized.LocusRuneInTrunkSlot);

        if (connectedRune1 != null)
        {
            if (uiTrunkNode_Serialized.connectedSlot1 != null && uiTrunkNode_Serialized.connectedSlot1.locusRuneInSlot != null)
                connectedRune1.FillFromSerialized(uiTrunkNode_Serialized.connectedSlot1);
        }
        if (connectedRune2 != null)
        {
            if (uiTrunkNode_Serialized.connectedSlot2 != null && uiTrunkNode_Serialized.connectedSlot2.locusRuneInSlot != null)
                connectedRune2.FillFromSerialized(uiTrunkNode_Serialized.connectedSlot2);
        }
        if (connectedRune3 != null)
        {
            if (uiTrunkNode_Serialized.connectedSlot3 != null && uiTrunkNode_Serialized.connectedSlot3.locusRuneInSlot != null)
                connectedRune3.FillFromSerialized(uiTrunkNode_Serialized.connectedSlot3);
        }
        if (connectedRune4 != null)
        {
            if (uiTrunkNode_Serialized.connectedSlot4 != null && uiTrunkNode_Serialized.connectedSlot4.locusRuneInSlot != null)
                connectedRune4.FillFromSerialized(uiTrunkNode_Serialized.connectedSlot4);
        }
    }
}