using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : BasicAbilityForm
{
    public NovaWorldAbility()
    {
        formType = FormType.Area;
    }

    void Start()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered)
        {

        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwner();

        AreaHitTrigger();
    }
}