using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class GameWorldReferenceClass : MonoBehaviour
{

    public static PlayerCharacterUnit GW_Player;
    public static Camera GW_PlayerCamera;
    public static List<RootUnit> GW_listOfNpcs = new List<RootUnit>();
    public static List<RootUnit> GW_listOfAllUnits = new List<RootUnit>();
    public static List<WorldItem> GW_listOfItems = new List<WorldItem>();
    public static List<WorldObject> GW_listOfObjects = new List<WorldObject>();
    public static List<ISpecialEffect> GW_listOfSpecialEffects = new List<ISpecialEffect>();
    public static int PartyMoney = 0;
    public static AbilitySlot HeldAbility = new AbilitySlot();

    public int GWS_difficultyMod;

    private void Start()
    {
        GW_Player = GameObject.Find("Player").GetComponent<PlayerCharacterUnit>();
        GW_PlayerCamera = Camera.main;
        UnityEngine.Object[] tempAbilityList = Resources.LoadAll("SO/Abilities", typeof(ScriptableObject));
        UnityEngine.Object[] tempStatusList = Resources.LoadAll("SO/Statuses", typeof(ScriptableObject));

        Cursor.lockState = CursorLockMode.Locked;
    }

    public static ISpecialEffect GetSpecialEffectFromId(int specialEffectId)
    {
        ISpecialEffect specialEffect = GW_listOfSpecialEffects.Find(x => x.specialEffectID == specialEffectId);

        if (specialEffect != null)
        {
            return specialEffect;
        }
        return null;
    }

    public static string GetSpecialEffectNameFromId(int specialEffectId)
    {
        ISpecialEffect specialEffect = GW_listOfSpecialEffects.Find(x => x.specialEffectID == specialEffectId);
        if (specialEffect != null)
        {
            return specialEffect.specialEffectName;
        }
        return "";
    }

    public static List<RootUnit> GetInAreaRootUnit(float searchArea, Vector3 searchPoint)
    {
        List<RootUnit> targetList = new List<RootUnit>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea, 1<<8|1<<12);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootUnit)))
                targetList.Add(c.GetComponent<RootUnit>());
        }

        return targetList;
    }

    public static RootUnit GetUnitByID(Guid guid)
    {
        foreach (RootUnit unit in GW_listOfAllUnits)
        {
            if (Guid.Equals(unit.unitID, guid))
            {
                return unit;
            }
        }

        return null;
    }
}