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

    public virtual void Use()
    {

    }
}