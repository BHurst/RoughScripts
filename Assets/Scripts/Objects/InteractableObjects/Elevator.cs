using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : InteractableObject
{
    public List<Transform> positions;
    int positionIndex = 0;
    public float speed = 1;
    bool on = false;


    public override void Use()
    {
        on = !on;
    }

    void FixedUpdate()
    {
        if(on)
        {
            transform.Translate((positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0].position - positions[positionIndex].position).normalized * speed * Time.deltaTime, Space.World);

            foreach (var item in GameWorldReferenceClass.GetNewRootUnitInSphere(4, transform.position, new List<RootCharacter>(), 1000))
            {
                item.transform.Translate((positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0].position - positions[positionIndex].position).normalized * speed * Time.deltaTime, Space.World);
            }

            if (Vector3.Distance(transform.position, positions[positionIndex + 1 < positions.Count ? positionIndex + 1 : 0].position) < .5f)
                positionIndex = (positionIndex + 1) % positions.Count;
        }
    }
}