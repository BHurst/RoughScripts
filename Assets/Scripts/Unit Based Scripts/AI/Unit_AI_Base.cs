using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_AI_Base : MonoBehaviour
{
    public NPCUnit unit;
    public NavMeshAgent agent;
    public AIActionState actionState = AIActionState.Idle;
    public RangeState rangeState = RangeState.OutOfPursueRange;
    public RangeState desiredRangeState = RangeState.OutOfPursueRange;

    public List<Transform> patrolWaypoints = new List<Transform>();
    public int waypointListIndex = 0;
    public float patrolSpeed = 6;
    public float wanderSpeed = 2;
    public float wanderTimer = 0;
    public float wanderInterval = 2;
    public int timesToWanderAtWaypoints = 1;
    public Vector3 lastPatrolDestination;
    public Vector3 lastPositionBeforeCombat;
    public bool inCombat = false;

    public void InitializeAI()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<NPCUnit>();
        agent.speed = patrolSpeed;
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
        lastPatrolDestination = patrolWaypoints[waypointListIndex].position;
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

    public void CheckRange(float meleeRange, float meleeRangeTolerance, float rangedRange, float rangedRangeTolerance, float stopPursueRange)
    {
        float targetDistance = Vector3.Distance(transform.position, unit.currentTarget.transform.position);

        if (targetDistance < meleeRange)
            rangeState = RangeState.Melee;
        else if (targetDistance < meleeRangeTolerance)
            rangeState = RangeState.Melee_Tolerance;
        else if (targetDistance < rangedRange)
            rangeState = RangeState.Ranged;
        else if (targetDistance < rangedRangeTolerance)
            rangeState = RangeState.Ranged_Tolerance;
        else if (targetDistance < stopPursueRange)
            rangeState = RangeState.OutOfAttackRange;
        else
            rangeState = RangeState.OutOfPursueRange;
    }

    public void StopPursue()
    {
        actionState = AIActionState.Patrolling;
        unit.currentCastingTime = 0;
        unit.abilityPreparingToCast = null;
        unit.currentTarget = null;
        agent.isStopped = false;
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0;
        agent.destination = lastPatrolDestination;
        inCombat = false;
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
                    agent.speed = wanderSpeed;
                    wanderInterval = Random.Range(1.5f, 3.5f);
                    agent.destination = patrolWaypoints[waypointListIndex].position + new Vector3(Random.Range(-3.5f, 3.5f), 0, Random.Range(-3.5f, 3.5f));
                    timesToWanderAtWaypoints--;
                    wanderTimer = 0;
                }
                else
                {
                    agent.speed = patrolSpeed;
                    waypointListIndex++;
                    GoToNextPoint();
                    timesToWanderAtWaypoints = Random.Range(1, 3);
                    wanderTimer = 0;
                }
            }
        }
    }

    public void FindTargetInRange(float range)
    {
        unit.currentTarget = GameWorldReferenceClass.GetInAreaPlayer(range, transform.position);
        if (unit.currentTarget != null)
        {
            inCombat = true;
            actionState = AIActionState.Attacking;
            agent.speed = unit.totalStats.MovementSpeed_Current;
        }
    }

    public void FindTargetInVision(float range, float visionAngle)
    {
        unit.currentTarget = GameWorldReferenceClass.GetInAreaPlayer(range, transform.position);
        if (unit.currentTarget != null)
        {
            inCombat = true;
            actionState = AIActionState.Attacking;
            agent.speed = unit.totalStats.MovementSpeed_Current;
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

    //Each section is within the previos one
    public enum RangeState
    {
        OutOfPursueRange,
        OutOfAttackRange,
        Ranged_Tolerance,
        Ranged,
        Melee_Tolerance,
        Melee
    }
}