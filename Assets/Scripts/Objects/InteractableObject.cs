using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public WorldObjectTooltipTrigger tooltipInfo;
    public int requiredItemId = -1;
    public bool unlocked = true;

    private void Awake()
    {
        tooltipInfo = GetComponent<WorldObjectTooltipTrigger>();
    }

    public void ActivatePrompt()
    {
        if (tooltipInfo != null)
            tooltipInfo.Activate();
    }

    public virtual void TriggerEntered(Collider collider)
    {

    }

    public virtual void TriggerExited(Collider collider)
    {

    }

    public virtual void Use()
    {

    }
}