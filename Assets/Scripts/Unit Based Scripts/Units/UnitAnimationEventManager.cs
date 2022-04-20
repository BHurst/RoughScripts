using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationEventManager : MonoBehaviour
{
    public RootUnit parentUnit;
    // Start is called before the first frame update
    void Awake()
    {
        parentUnit = GetComponentInParent<RootUnit>();
    }

    public void CastEvent() => parentUnit.Cast();
}