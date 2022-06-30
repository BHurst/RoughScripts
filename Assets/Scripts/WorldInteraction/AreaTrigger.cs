using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public InteractableObject reportTarget;

    private void OnTriggerEnter(Collider collider)
    {
        reportTarget.TriggerEntered(collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        reportTarget.TriggerExited(collider);
    }
}