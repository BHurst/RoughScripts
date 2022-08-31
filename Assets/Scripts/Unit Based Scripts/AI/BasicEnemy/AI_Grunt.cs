using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Grunt : Unit_AI_Base, Unit_AI_Brain
{
    public float meleeRange = 2;
    public float meleeRangeTolerance = 3;
    public float rangedRange = 15;
    public float rangeRangeTolerance = 20;
    public float stopPursueRange = 25;
    public float leashRange = 25;

    public float aggroRange = 20; //Distance at which unit will decide to engage into combat

    private void Start()
    {
        InitializeAI();
        wanderInterval = Random.Range(1.5f, 3.5f);
    }

    public override RootAbility DetermineAbilityToUse()
    {
        return unit.knownAbilities[0];
    }

    public void Pursue()
    {
        CheckRange(meleeRange, meleeRangeTolerance, rangedRange, rangeRangeTolerance, stopPursueRange);
        var chaseDistance = Vector3.Distance(transform.position, lastPositionBeforeCombat);

        if (rangeState != RangeState.OutOfPursueRange && chaseDistance < leashRange)
        {
            if (UtilityService.LineOfSightCheckRootUnit(unit.transform.position + unit.eyesOffset, unit.currentTarget) != new Vector3() && rangeState >= desiredRangeState && !RootAbility.NullorUninitialized(unit.abilityPreparingToCast))
            {
                FaceTarget();
                unit.currentTargetPoint = unit.currentTarget.transform.position;
                unit.ActiveAbilityCheck();
            }
            else if (UtilityService.LineOfSightCheckRootUnit(unit.transform.position + unit.eyesOffset, unit.currentTarget) != new Vector3() && rangeState >= desiredRangeState)
            {
                switch (desiredRangeState)
                {
                    case RangeState.Ranged:
                        agent.stoppingDistance = meleeRange;
                        break;
                    case RangeState.Melee:
                        agent.stoppingDistance = rangedRange;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                unit.abilityPreparingToCast = null;
                unit.currentCastingTime = 0;
                agent.destination = unit.currentTarget.transform.position;
            }
        }
        else
        {
            StopPursue();
        }
    }

    public override void Tick()
    {
        if (unit.isAlive == true)
        {
            if (actionState == AIActionState.Patrolling)
            {
                Patrol();
                if (unit.hostility == Hostility.Hostile)
                    FindTargetInRange(aggroRange);
            }
            else if (actionState == AIActionState.Attacking)
            {
                Pursue();
            }
        }
    }
}