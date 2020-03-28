using UnityEngine;
using System.Collections;

public class UnitHighlight : MonoBehaviour {

    public Transform target;
    public Vector3 offset = new Vector3(0,5,0);

    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}