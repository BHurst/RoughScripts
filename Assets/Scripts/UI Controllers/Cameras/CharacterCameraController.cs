using UnityEngine;
using System.Collections;

public class CharacterCameraController : MonoBehaviour {

    public Transform target;

    void Start()
    {
        this.transform.parent = target.transform;
    }

    //As of right now there are cameras attatched to the actual party members and will follow them as they move.
    //This will later be changed so that there is a camera on a duplicate model off in a non accessable area
    //so that they will have animated character portraits.
}