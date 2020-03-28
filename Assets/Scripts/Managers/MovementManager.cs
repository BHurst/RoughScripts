using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class MovementManager {

	public static void Move(NPCUnit unit, Vector3 point)
    {
        NavMeshPath p = new NavMeshPath();
        unit.nav.CalculatePath(point, p);
        unit.nav.SetPath(p);
    }

    public static void MoveFormation(List<RootUnit> units, Vector3 point)
    {

    }

    public static void Stop(NPCUnit unit)
    {
        unit.nav.ResetPath();
    }

    public static void StopAll(List<RootUnit> units)
    {

    }


}