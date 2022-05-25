using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
                UITooltipController.Show(headerContent, shorthandContent, bodyContent, tertiaryContent);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UITooltipController.Hide();
    }

    public void Clear()
    {
        headerContent = "";
        shorthandContent = "";
        bodyContent = "";
        tertiaryContent = "";
    }
}