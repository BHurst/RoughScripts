using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : BasicAbilityForm
{
    public PointWorldAbility()
    {
        formType = FormType.None;
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