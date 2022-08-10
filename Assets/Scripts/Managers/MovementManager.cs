using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class MovementManager {

	public static void Move(NPCUnit unit, Vector3 point)
    {
        NavMeshPath p = new NavMeshPath();
        unit.unitBrain.agent.CalculatePath(point, p);
        unit.unitBrain.agent.SetPath(p);
    }

    public static void MoveFormation(List<RootCharacter> units, Vector3 point)
    {

    }

    public static void Stop(NPCUnit unit)
    {
        unit.unitBrain.agent.ResetPath();
    }

    public static void StopAll(List<RootCharacter> units)
    {

    }
}