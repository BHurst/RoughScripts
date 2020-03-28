using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectRouting : MonoBehaviour {

    public static void Dash(RootUnit target)
    {
        target.GetComponent<Rigidbody>().AddRelativeForce(0,0,5);
    }

    public static void Charm(RootUnit target)
    {
        //TODO Make charm do something
    }

    public static void Cleanse(RootUnit target)
    {
        target.state.ClearState();
        target.currentStatusEffects.Clear();
    }
}