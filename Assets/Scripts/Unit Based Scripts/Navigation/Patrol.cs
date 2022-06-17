using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NPCUnit unit;
    public List<Transform> points = new List<Transform>();
    public float timer = 0;
    public int destPoint = 0;
    private NavMeshAgent agent;
    public int timesToWander = 1;
    public float wanderTime = 2;
    public Vector3 whereIWasGoing;
    public bool aggroed = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<NPCUnit>();
        agent.speed = 8.4315f;
        wanderTime = Random.Range(1.5f, 3.5f);
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if (destPoint == points.Count)
            destPoint = 0;
        agent.destination = points[destPoint].position;
    }

    public void FaceTarget()
    {
        Vector3 targetPostition = new Vector3(unit.currentTarget.transform.position.x, transform.position.y, unit.currentTarget.transform.position.z);
        transform.LookAt(targetPostition);
    }

    void Update()
    {
        if(agent.enabled)
        {
            if (unit.currentTarget != null)
            {
                var targetDistance = Vector3.Distance(transform.position, unit.currentTarget.transform.position);
                if (unit.currentCastingTime > 0)
                {
                    agent.isStopped = true;
                    FaceTarget();
                }
                else
                {
                    if (aggroed == false)
                    {
                        whereIWasGoing = agent.destination;
                        aggroed = true;
                    }

                    agent.destination = unit.currentTarget.transform.position;

                    if (targetDistance < 10 && UtilityService.LineOfSightCheckRootUnit(unit.transform.position + unit.eyesOffset, unit.currentTarget) != new Vector3())
                        agent.isStopped = true;
                    else if (targetDistance > 25)
                    {
                        unit.currentCastingTime = 0;
                        unit.abilityPreparingToCast = null;
                        unit.currentTarget = null;
                        agent.isStopped = false;
                    }
                    else
                        agent.isStopped = false;
                }
            }
            else
            {
                if (aggroed)
                {
                    agent.destination = whereIWasGoing;
                    aggroed = false;
                }
                if (!agent.pathPending && agent.remainingDistance < 0.25f)
                {
                    timer += Time.deltaTime;
                    if (timer > wanderTime)
                    {
                        if (timesToWander > 0)
                        {
                            wanderTime = Random.Range(1.5f, 3.5f);
                            agent.destination = points[destPoint].position + new Vector3(Random.Range(-3.5f, 3.5f), 0, Random.Range(-3.5f, 3.5f));
                            timesToWander--;
                            timer = 0;
                            agent.speed = 15f;
                        }
                        else
                        {
                            destPoint++;
                            GotoNextPoint();
                            timesToWander = Random.Range(1, 3);
                            timer = 0;
                            agent.speed = 8.4315f;
                        }
                    }

                }
            }
        }
    }
}