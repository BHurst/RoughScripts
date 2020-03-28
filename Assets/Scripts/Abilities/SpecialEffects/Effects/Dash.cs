using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ISpecialEffect
{
    public void Effect(RootUnit target)
    {
        target.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 5);
    }
}