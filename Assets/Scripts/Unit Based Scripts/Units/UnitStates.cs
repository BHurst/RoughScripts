using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStates {
    public bool Burning = false;
    public bool Stunned = false;
    public bool Slowed = false;
    public bool Wet = false;
    public bool Rooted = false;
    public bool Poisoned = false;
    public bool Electrified = false;
    public bool Cursed = false;
    public bool Bleeding = false;

    public void ClearState()
    {
        Burning = false;
        Stunned = false;
        Slowed = false;
        Wet = false;
        Rooted = false;
        Poisoned = false;
        Electrified = false;
        Cursed = false;
        Bleeding = false;
    }
}