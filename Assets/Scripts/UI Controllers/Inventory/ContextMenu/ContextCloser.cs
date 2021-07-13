using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextCloser : MonoBehaviour, IPointerClickHandler
{
    public GameObject contextMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        contextMenu.SetActive(false);
        foreach (Transform kid in contextMenu.transform)
            kid.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }
}