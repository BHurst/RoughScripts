using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static event EventHandler<RootAbilityForm> abilityHitTrigger;
    public static event EventHandler<RootAbilityForm> abilityCastTrigger;

    public static void AbilityHitTrigger(object sender, RootAbilityForm ability, RootCharacter target, Vector3 location)
    {
        abilityHitTrigger?.Invoke(sender, ability);
    }

    public static void AbilityCastTrigger(object sender, RootAbilityForm ability, RootCharacter target, Vector3 location)
    {
        abilityCastTrigger?.Invoke(sender, ability);
    }
}