using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string headerContent = "";
    public string shorthandContent = "";
    public string bodyContent = "";
    public string tertiaryContent = "";

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Cursor.visible)
        {
            if (!string.IsNullOrEmpty(headerContent))
                TooltipController.Show(headerContent, shorthandContent, bodyContent, tertiaryContent);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipController.Hide();
    }

    public void Clear()
    {
        headerContent = "";
        shorthandContent = "";
        bodyContent = "";
        tertiaryContent = "";
    }
}