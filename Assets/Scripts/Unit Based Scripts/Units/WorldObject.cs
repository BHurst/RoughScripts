using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

    public string entityName = "DEFAULT";
    public Vector3 location;
    public float distanceToBeInteracted = 2;

    public void Interact()
    {
        Debug.Log(entityName + " has been interacted with.");
    }
}