using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class GameWorldReferenceClass : MonoBehaviour
{

    public static PlayerCharacterUnit GW_Player;
    public static Camera GW_PlayerCamera;
    public static List<RootUnit> GW_listOfNpcs = new List<RootUnit>();
    public static List<RootUnit> GW_listOfAllCharacters = new List<RootUnit>();
    public static List<WorldItem> GW_listOfItems = new List<WorldItem>();
    public static List<WorldObject> GW_listOfObjects = new List<WorldObject>();
    public static List<RootAbility> GW_listOfAbilities = new List<RootAbility>();
    public static int PartyMoney = 0;
    public static AbilitySlot HeldAbility = new AbilitySlot();

    public enum HitType
    {
        Hit,
        Crit
    }

    public int GWS_difficultyMod;

    private void Start()
    {
        GW_Player = GameObject.Find("Player1").GetComponent<PlayerCharacterUnit>();
        GW_PlayerCamera = Camera.main;
        UnityEngine.Object[] tempList = Resources.LoadAll("SO/Abilities", typeof(ScriptableObject));

        foreach (UnityEngine.Object o in tempList)
        {
            RootAbility temp = (RootAbility)o;
            GW_listOfAbilities.Add(temp);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    public static RootAbility GetAbilityFromId(RootUnit unit, int abilityId)
    {
        RootAbility containedAbility = unit.availableAbilities.Find(x => x.abilityID == abilityId);

        if (containedAbility != null)
        {
            return containedAbility;
        }
        return null;
    }

    public static string GetAbilityNameFromId(RootUnit unit, int abilityId)
    {
        RootAbility containedAbility = unit.availableAbilities.Find(x => x.abilityID == abilityId);
        if (containedAbility != null)
        {
            return containedAbility.stats.abilityName;
        }
        return "";
    }
}