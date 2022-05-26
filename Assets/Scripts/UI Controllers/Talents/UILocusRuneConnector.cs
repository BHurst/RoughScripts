using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILocusRuneConnector : MonoBehaviour, IPointerClickHandler
{
    public UILocusRune ParentUILocusRune;
    public UILocusRune attachedlocusRune;
    public Dir dir;

    private void Start()
    {
        if (ParentUILocusRune == null)
            ParentUILocusRune = GetComponentInParent<UILocusRune>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (dir)
        {
            case Dir.N:
                ParentUILocusRune.ConnectNorth();
                break;
            case Dir.E:
                ParentUILocusRune.ConnectEast();
                break;
            case Dir.S:
                ParentUILocusRune.ConnectSouth();
                break;
            case Dir.W:
                ParentUILocusRune.ConnectWest();
                break;
            default:
                break;
        }
    }

    public enum Dir
    {
        N,
        E,
        S,
        W
    }
}