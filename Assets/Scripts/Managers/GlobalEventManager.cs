using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static event EventHandler<WorldAbility> abilityHitTrigger;
    public static event EventHandler<WorldAbility> abilityCastTrigger;

    public static void AbilityHitTrigger(object sender, WorldAbility ability, RootUnit target, Vector3 location)
    {
        abilityHitTrigger?.Invoke(sender, ability);
    }

    public static void AbilityCastTrigger(object sender, WorldAbility ability, RootUnit target, Vector3 location)
    {
        abilityCastTrigger?.Invoke(sender, ability);
    }
}