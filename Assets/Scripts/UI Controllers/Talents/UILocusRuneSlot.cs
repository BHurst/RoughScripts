using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILocusRuneSlot : MonoBehaviour, IPointerClickHandler
{
    Image background;
    public Talent_SelectLocusRunePane SelectLocusRunePane;
    public CharacterTalentsPane characterTalents;
    public UILocusRuneSlot previousSlot;
    public UILocusRune locusRuneInSlot;
    public bool available = false;
    bool started = false;
    public int distanceFromSplit;
    public Transform ChildSlots;
    public UILocusRuneSlot connectedRune1;
    public UILocusRuneSlot connectedRune2;
    public UILocusRuneSlot connectedRune3;
    public UILocusRuneSlot connectedRune4;

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
        NullGarbage();
    }

    void NullGarbage()
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
        started = true;
        locusRuneInSlot.gameObject.SetActive(false);
        SetUnavailable();
    }

    public void SetUnavailable()
    {
        background.color = Color.black;
        available = false;
    }

    public void SetAvailable()
    {
        if (started == false)
            NullGarbage();
        background.color = Color.white;
        available = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (available)
            SelectLocusRunePane.Show(this);
    }

    public void PutRuneInSlot(LocusRuneItem locusRuneItem)
    {
        GameObject prefab = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune"), transform) as GameObject;
        UILocusRune newRune = prefab.GetComponent<UILocusRune>();
        newRune.transform.localScale = new Vector3(1, 1);
        newRune.LocusRune = locusRuneItem.LocusRune;
        newRune.transform.position = transform.position;
        locusRuneInSlot = newRune;

        if (connectedRune1 != null)
            connectedRune1.SetAvailable();
        if (connectedRune2 != null)
            connectedRune2.SetAvailable();
        if (connectedRune3 != null)
            connectedRune3.SetAvailable();
        if (connectedRune4 != null)
            connectedRune4.SetAvailable();

        PlayerCharacterUnit.player.availableLocusRuneItems.Remove(locusRuneItem);
        available = false;
    }

    public void RemoveRuneInSlot()
    {
        
    }

    public void PutRuneInSlot(LocusRune locusRune)
    {
        locusRuneInSlot.gameObject.SetActive(true);
        locusRuneInSlot.transform.localScale = new Vector3(1, 1);
        locusRuneInSlot.LocusRune = locusRune;
        locusRuneInSlot.transform.position = transform.position;

        if (connectedRune1 != null)
            connectedRune1.SetAvailable();
        if (connectedRune2 != null)
            connectedRune2.SetAvailable();
        if (connectedRune3 != null)
            connectedRune3.SetAvailable();
        if (connectedRune4 != null)
            connectedRune4.SetAvailable();

        available = false;
    }

    public void FillFromSerialized(UILocusRuneSlot_Serialized uiLocusRuneSlot_Serialized)
    {
        PutRuneInSlot(uiLocusRuneSlot_Serialized.locusRuneInSlot.LocusRune);
        locusRuneInSlot.FillFromSerialized(uiLocusRuneSlot_Serialized.locusRuneInSlot);
        available = uiLocusRuneSlot_Serialized.available;
        if(uiLocusRuneSlot_Serialized.connectedRune1 != null && uiLocusRuneSlot_Serialized.connectedRune1.locusRuneInSlot != null)
        {
            connectedRune1.FillFromSerialized(uiLocusRuneSlot_Serialized.connectedRune1);
        }
        if (uiLocusRuneSlot_Serialized.connectedRune2 != null && uiLocusRuneSlot_Serialized.connectedRune2.locusRuneInSlot != null)
        {
            connectedRune2.FillFromSerialized(uiLocusRuneSlot_Serialized.connectedRune2);
        }
        if (uiLocusRuneSlot_Serialized.connectedRune3 != null && uiLocusRuneSlot_Serialized.connectedRune3.locusRuneInSlot != null)
        {
            connectedRune3.FillFromSerialized(uiLocusRuneSlot_Serialized.connectedRune3);
        }
        if (uiLocusRuneSlot_Serialized.connectedRune4 != null && uiLocusRuneSlot_Serialized.connectedRune4.locusRuneInSlot != null)
        {
            connectedRune4.FillFromSerialized(uiLocusRuneSlot_Serialized.connectedRune4);
        }
    }
}