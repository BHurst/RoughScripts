using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbilityForm : MonoBehaviour
{
    public AbilityChaperone chaperone;
    public RootAbility ability;
    public Transform targetPreference;

    public float timer = 0;
    public RaycastHit spellRay;
    public RaycastHit camRay;
    public Rigidbody skeleton;
    public ParticleSystem pS;

    public virtual void ApplyHit(RootCharacter target)
    {
        
    }

    public virtual void ApplyDoT(RootCharacter target)
    {
        
    }

    public virtual void ApplyAreaDoT(RootCharacter target)
    {
        
    }
}