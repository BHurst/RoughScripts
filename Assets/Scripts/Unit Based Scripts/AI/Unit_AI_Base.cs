using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_AI_Base : MonoBehaviour
{
    public NPCUnit unit;
    public NavMeshAgent agent;
    public AIActionState actionState = AIActionState.Idle;

    public List<Transform> patrolWaypoints = new List<Transform>();
    public int waypointListIndex = 0;
    public float wanderTimer = 0;
    public float wanderInterval = 2;
    public int timesToWanderAtWaypoints = 1;
    public Vector3 lastIdleDestination;

    public bool aggroed = false;
    public float minPreferredDistance = 15; // Distance at which unit will attempt to attack
    public float maxPreferredDistance = 20; // Distance at which unit will STOP attempting to attack and will attempt to get back to the minPreferredDistance

    public void InitializeAI()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<NPCUnit>();
    }

    public void GoToNextPoint()
    {
        // Returns if no points have been set up
        if (patrolWaypoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if (waypointListIndex == patrolWaypoints.Count)
            waypointListIndex = 0;
        agent.destination = patrolWaypoints[waypointListIndex].position;
    }

    public void FaceTarget()
    {
        Vector3 targetPostition = new Vector3(unit.currentTarget.transform.position.x, transform.position.y, unit.currentTarget.transform.position.z);
        transform.LookAt(targetPostition);
    }

    public virtual RootAbility DetermineAbilityToUse()
    {
        return null;
    }

    public void Pursue()
    {
        var targetDistance = Vector3.Distance(transform.position, unit.currentTarget.transform.position);
        var retreatDistance = Vector3.Distance(transform.position, lastIdleDestination);

        if (targetDistance < 25 && retreatDistance < 25)
        {
            if(UtilityService.LineOfSightCheckRootUnit(unit.transform.position + unit.eyesOffset, unit.currentTarget) != new Vector3() && targetDistance <= maxPreferredDistance && !RootAbility.NullorUninitialized(unit.abilityPreparingToCast))
            {
                FaceTarget();
                unit.currentTargetPoint = unit.currentTarget.transform.position;
                unit.ActiveAbilityCheck();
            }
            else if (UtilityService.LineOfSightCheckRootUnit(unit.transform.position + unit.eyesOffset, unit.currentTarget) != new Vector3() && targetDistance <= minPreferredDistance)
            {
                if (RootAbility.NullorUninitialized(unit.abilityPreparingToCast))
                {
                    unit.abilityPreparingToCast = DetermineAbilityToUse();
                    agent.stoppingDistance = minPreferredDistance;
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

    public void StopPursue()
    {
        actionState = AIActionState.Patrolling;
        unit.currentCastingTime = 0;
        unit.abilityPreparingToCast = null;
        unit.currentTarget = null;
        agent.isStopped = false;
        agent.destination = lastIdleDestination;
        aggroed = false;
    }

    public void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.25f)
        {
            wanderTimer += Time.deltaTime;
            if (wanderTimer > wanderInterval)
            {
                if (timesToWanderAtWaypoints > 0)
                {
                    wanderInterval = Random.Range(1.5f, 3.5f);
                    agent.destination = patrolWaypoints[waypointListIndex].position + new Vector3(Random.Range(-3.5f, 3.5f), 0, Random.Range(-3.5f, 3.5f));
                    timesToWanderAtWaypoints--;
                    wanderTimer = 0;
                }
                else
                {
                    waypointListIndex++;
                    GoToNextPoint();
                    timesToWanderAtWaypoints = Random.Range(1, 3);
                    wanderTimer = 0;
                }
            }
        }
    }

    public void FindTarget()
    {
        unit.currentTarget = GameWorldReferenceClass.GetInAreaPlayer(20, transform.position);
        if (unit.currentTarget != null)
        {
            aggroed = true;
            actionState = AIActionState.Attacking;
            lastIdleDestination = transform.position;
        }
    }

    public void ChaseTarget()
    {

    }

    public virtual void Tick()
    {

    }

    public enum AIActionState
    {
        Idle,
        Patrolling,
        Attacking
    }
}