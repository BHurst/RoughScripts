using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static event EventHandler<_WorldAbilityForm> abilityHitTrigger;
    public static event EventHandler<_WorldAbilityForm> abilityCastTrigger;

    public static void AbilityHitTrigger(object sender, _WorldAbilityForm ability, RootCharacter target, Vector3 location)
    {
        abilityHitTrigger?.Invoke(sender, ability);
    }

    public static void AbilityCastTrigger(object sender, _WorldAbilityForm ability, RootCharacter target, Vector3 location)
    {
        abilityCastTrigger?.Invoke(sender, ability);
    }
}