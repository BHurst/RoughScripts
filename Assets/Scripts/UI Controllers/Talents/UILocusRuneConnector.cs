using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILocusRuneConnector : MonoBehaviour, IPointerClickHandler
{
    public Vector3 dir = new Vector3(0,0,0);
    public SelectLocusRunePane SelectLocusRunePane;
    public UILocusRune runeConnectingFrom;
    public UILocusRune runeConnectingTo;

    private void Start()
    {
        if (runeConnectingFrom == null)
            runeConnectingFrom = GetComponentInParent<UILocusRune>();
        if (SelectLocusRunePane == null)
            SelectLocusRunePane = GameObject.Find("SelectLocusRunePane").GetComponent<SelectLocusRunePane>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectLocusRunePane.Show(this);
    }

    public Vector3 GetEndPoint()
    {
        return new Vector3(((RectTransform)transform).sizeDelta.y * Mathf.Sin(transform.rotation.eulerAngles.z * -1 * Mathf.Deg2Rad),((RectTransform)transform).sizeDelta.y * Mathf.Cos(transform.rotation.eulerAngles.z * -1 * Mathf.Deg2Rad));
    }
}