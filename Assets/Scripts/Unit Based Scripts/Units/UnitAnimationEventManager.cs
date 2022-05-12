using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationEventManager : MonoBehaviour
{
    public RootCharacter parentUnit;
    // Start is called before the first frame update
    void Awake()
    {
        parentUnit = GetComponentInParent<RootCharacter>();
    }

    public void CastEvent() => parentUnit.Cast();
}