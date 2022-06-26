using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : BasicAbilityForm
{
    float strikeTimer;
    public StrikeWorldAbility()
    {
        formType = FormType.Area;
        strikeTimer = 0;
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
    }

    private void Update()
    {
        strikeTimer += Time.deltaTime;

        if (strikeTimer >= ability.snapshot.duration)
            AreaHitTrigger();
    }
}