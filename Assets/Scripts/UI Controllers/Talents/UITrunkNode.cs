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
    public UILocusRuneSlot connectedRune1;
    public UILocusRuneSlot connectedRune2;
    public UILocusRuneSlot connectedRune3;
    public UILocusRuneSlot connectedRune4;
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
        GameObject prefab = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune"), transform) as GameObject;
        UILocusRune newRune = prefab.GetComponent<UILocusRune>();
        newRune.transform.localScale = new Vector3(1, 1);
        newRune.transform.position = transform.position;
        newRune.LocusRune = trunkPreset.Preset();

        runeInTrunkSlot = newRune;
    }
}