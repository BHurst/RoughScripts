using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectTooltipTrigger : MonoBehaviour
{
    public string headerContent = "";
    public string shorthandContent = "";
    public string bodyContent = "";
    public string tertiaryContent = "";

    public void Activate()
    {
        if (Cursor.visible)
        {
            if (!string.IsNullOrEmpty(headerContent))
                WorldObjectTooltipController.Show(headerContent, shorthandContent, bodyContent, tertiaryContent);
        }
    }

    public void Deactivate()
    {
        WorldObjectTooltipController.Hide();
    }

    public void Clear()
    {
        headerContent = "";
        shorthandContent = "";
        bodyContent = "";
        tertiaryContent = "";
    }
}