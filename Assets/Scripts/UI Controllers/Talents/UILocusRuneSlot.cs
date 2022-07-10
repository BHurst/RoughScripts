using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILocusRuneSlot : MonoBehaviour, IPointerClickHandler
{
    
    public Talent_SelectLocusRunePane SelectLocusRunePane;
    public CharacterTalentsPane characterTalents;
    public UILocusRuneSlot previousSlot;
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
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void PutRuneInSlot(LocusRuneItem locusRuneItem)
    {
        GameObject prefab = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune"), transform) as GameObject;
        UITalentBranchNode newRune = prefab.GetComponent<UITalentBranchNode>();
        newRune.transform.localScale = new Vector3(1, 1);
        newRune.runeInNode = locusRuneItem.locusRune;
        newRune.transform.position = transform.position;
        //locusRuneInSlot = newRune;

        PlayerCharacterUnit.player.availableLocusRuneItems.Remove(locusRuneItem);
        available = false;
    }

    public void RemoveRuneInSlot()
    {

    }
}