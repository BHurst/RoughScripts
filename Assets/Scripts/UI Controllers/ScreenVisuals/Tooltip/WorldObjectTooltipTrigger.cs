using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectTooltipTrigger : MonoBehaviour
{
    public bool tooltipEnabled = true;
    public string headerContent = "";
    public string shorthandContent = "";
    public string bodyContent = "";
    public string tertiaryContent = "";

    public void Activate()
    {
        if (tooltipEnabled)
            WorldObjectTooltipController.Show(headerContent, shorthandContent, bodyContent, tertiaryContent);
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