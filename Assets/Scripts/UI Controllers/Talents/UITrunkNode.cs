using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrunkNode : MonoBehaviour
{
    public TrunkPresetBase trunkPreset;
    Image background;
    public SelectLocusRunePane SelectLocusRunePane;
    public CharacterTalentsPane characterTalents;
    public UITrunkNode previousSlot;
    public bool available = false;
    public Transform ChildSlots;
    public UILocusRuneSlot connectedRune1;
    public UILocusRuneSlot connectedRune2;
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
    }

    private void Start()
    {
        if (characterTalents == null)
            characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        if (SelectLocusRunePane == null)
            SelectLocusRunePane = GameObject.Find("SelectLocusRunePane").GetComponent<SelectLocusRunePane>();
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
            }
        }
    }

    public void SetUnavailable()
    {
        background.color = Color.black;
        available = false;
    }

    public void SetAvailable()
    {
        background.color = Color.white;
        available = true;
    }

    public void LoadPreset()
    {
        if (loaded == false)
        {
            GameObject prefab = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune"), transform) as GameObject;
            UILocusRune newRune = prefab.GetComponent<UILocusRune>();
            newRune.DelayedStart();
            newRune.transform.localScale = new Vector3(1, 1);
            newRune.transform.position = transform.position;

            newRune.SetRune(trunkPreset.Preset());

            if (connectedRune1 != null)
                connectedRune1.SetAvailable();
            if (connectedRune2 != null)
                connectedRune2.SetAvailable();
            loaded = true;
        }
    }
}