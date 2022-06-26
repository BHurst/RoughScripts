using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : BasicAbilityForm
{
    public StrikeWorldAbility()
    {
        formType = FormType.Area;
    }

    void Start()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwnerTarget();

        AreaHitTrigger();
    }
}