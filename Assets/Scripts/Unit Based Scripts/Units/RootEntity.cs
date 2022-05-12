using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootEntity : MonoBehaviour
{
    public Guid unitID = Guid.NewGuid();
    public EntityType entityType = EntityType.None;
    public Vector3 location;
    public string unitName = "DummyName";

    public enum EntityType
    {
        None,
        Hazard,
        Object,
        Character,
        Player
    }
}