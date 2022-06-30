using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : InteractableObject
{
    List<Rigidbody> objectsOnPlatform = new List<Rigidbody>();
    public Transform directionToMove;
    public List<Transform> positions;
    public Transform waypointParent;
    int positionIndex = 0;
    public float speed = 1;
    public bool on = false;
    public bool smooth = false;
    public float smoothSpeed = 90;

    private void Start()
    {
        foreach (Transform item in waypointParent)
        {
            positions.Add(item);
        }
        directionToMove.LookAt(positions[(positionIndex + 1) % positions.Count]);
    }


    public override void Use()
    {
        on = !on;
    }

    public override void TriggerEntered(Collider collider)
    {
        objectsOnPlatform.Add(collider.GetComponent<Rigidbody>());
    }

    public override void TriggerExited(Collider collider)
    {
        objectsOnPlatform.Remove(collider.GetComponent<Rigidbody>());
    }

    void FixedUpdate()
    {
        if (smooth)
            directionToMove.rotation = Quaternion.RotateTowards(directionToMove.rotation, Quaternion.LookRotation(positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0].position - transform.position).normalized, smoothSpeed * Time.deltaTime);
        else
            directionToMove.LookAt(positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0]);
        if (on)
        {

            transform.Translate(directionToMove.forward * speed * Time.deltaTime, Space.World);

            for (int i = objectsOnPlatform.Count - 1; i >= 0; i--)
            {
                if (objectsOnPlatform[i] != null)
                    objectsOnPlatform[i].transform.Translate(directionToMove.forward * speed * Time.deltaTime, Space.World);
                else
                    objectsOnPlatform.RemoveAt(i);
            }
            
            if (Vector3.Distance(transform.position, positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0].position) < .5f)
                positionIndex = (positionIndex + 1) % positions.Count;
        }
    }
}