using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform parentShoulders;
    float x = 0;
    float y = 0;
    float mS = .25f;
    Vector3 rot = new Vector3();

    void Start()
    {
        parentShoulders = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parentShoulders.position + new Vector3(0, 1.8f, 0);
        x += Mouse.current.delta.x.ReadValue();
        y -= Mouse.current.delta.y.ReadValue();
        if (y > 340)
            y = 340;
        if (y < -340)
            y = -340;
        rot = new Vector3(y * mS, x * mS, rot.z);
        transform.eulerAngles = rot;
    }
}