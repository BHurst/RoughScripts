using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    public Transform pivotPoint;
    public DoorState state = DoorState.Closed;
    public Quaternion openRotation = new Quaternion(0, 0, 0, 1);
    public Quaternion closedRotation = new Quaternion(0, 0, 0, 1);
    public float timeToOpen = 1;
    float timeElapsed = 0;

    private void Start()
    {
        tooltipInfo.bodyContent = "Open door";
    }

    public override void Use()
    {
        if (state == DoorState.Closed || state == DoorState.Closing)
            state = DoorState.Opening;
        else
            state = DoorState.Closing;
    }

    void Update()
    {
        if (state == DoorState.Closing)
        {
            timeElapsed += Time.deltaTime;
            pivotPoint.rotation = Quaternion.RotateTowards(pivotPoint.rotation, closedRotation, timeToOpen * 90 * Time.deltaTime);
            if (Quaternion.Angle(pivotPoint.rotation, closedRotation) < 1)
            {
                pivotPoint.rotation = closedRotation;
                state = DoorState.Closed;
                timeElapsed = 0;
            }
        }
        else if (state == DoorState.Opening)
        {
            timeElapsed += Time.deltaTime;
            pivotPoint.rotation = Quaternion.RotateTowards(pivotPoint.rotation, openRotation, timeToOpen * 90 * Time.deltaTime);
            if (Quaternion.Angle(pivotPoint.rotation, openRotation) < 1)
            {
                pivotPoint.rotation = openRotation;
                state = DoorState.Open;
                timeElapsed = 0;
            }
        }
    }

    public enum DoorState
    {
        Open,
        Opening,
        Closed,
        Closing
    }
}