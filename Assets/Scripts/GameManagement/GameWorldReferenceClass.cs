using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;

[Serializable]
public class GameWorldReferenceClass : MonoBehaviour
{
    public static Camera GW_PlayerCamera;
    public EnemyManager enemyManager;
    public static List<RootCharacter> GW_listOfAllUnits = new List<RootCharacter>();
    public static List<WorldItem> GW_listOfItems = new List<WorldItem>();
    public static List<WorldObject> GW_listOfObjects = new List<WorldObject>();
    public static List<HazardBase> GW_listOfHazards = new List<HazardBase>();
    public static GameObject respawnPoint;
    public static List<Type> GW_ItemTypes;

    public static List<ValidStatCombo> validStats = new List<ValidStatCombo>();

    public int GWS_difficultyMod;
    public static float inputBuffer = .5f;

    private void Start()
    {
        respawnPoint = GameObject.Find("Respawn");
        GW_PlayerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;

        var fields = typeof(UnitStats).GetFields();

        foreach (var item in fields)
        {
            var split = item.Name.Split("_");
            if (split[1] != "Current" && split[1] != "Default")
            {
                ValidStatCombo validStatCombo = new ValidStatCombo();
                validStatCombo.stat = split[0];
                validStatCombo.aspect = split[1];
                if (split.Length == 3 && split[2] != "Current" && split[2] != "Default")
                    validStatCombo.method = split[2];
                else
                    validStatCombo.method = "";

                validStats.Add(validStatCombo);
            }
        }
        ModifierBaseManager setMain = new ModifierBaseManager();
        QuestManager.CreateQuestList();
    }

    public static bool IsStatComboValid(string stat, string aspect, string method)
    {
        foreach (var item in validStats)
        {
            if (item.stat == stat && item.aspect == aspect && (method == "" || item.method == method))
                return true;
        }
        return false;
    }

    public static void Respawn()
    {
        PlayerCharacterUnit.player.animator.Play("Idle");
        PlayerCharacterUnit.player.transform.position = respawnPoint.transform.position;
        PlayerCharacterUnit.player.unitBody.velocity = new Vector3(0, 0, 0);
        PlayerCharacterUnit.player.activeStatuses.Clear();
        PlayerCharacterUnit.player.StopCast();
        PlayerCharacterUnit.player.totalStats.Health_Current = PlayerCharacterUnit.player.totalStats.Health_Max;
        PlayerCharacterUnit.player.totalStats.Mana_Current = PlayerCharacterUnit.player.totalStats.Mana_Max;
        PlayerCharacterUnit.player.totalStats.RefillReserve();
        PlayerCharacterUnit.player.isAlive = true;
    }

    public static List<DestructableObject> GetDestructableObjectsInSphere(float searchArea, Vector3 searchPoint)
    {
        List<DestructableObject> targetList = new List<DestructableObject>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(DestructableObject)))
                targetList.Add(c.GetComponent<DestructableObject>());
        }

        return targetList;
    }

    public static List<DestructableObject> GetDestructableObjectsInCapsule(Vector3 startPoint, Vector3 endPoint, float width)
    {
        List<DestructableObject> targetList = new List<DestructableObject>();
        Collider[] collisionCapsule;
        Collider[] orderedCollisionSphere;

        collisionCapsule = Physics.OverlapCapsule(startPoint, endPoint, width);

        orderedCollisionSphere = collisionCapsule.OrderBy(x => (startPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(DestructableObject)))
                targetList.Add(c.GetComponent<DestructableObject>());
        }

        return targetList;
    }

    public static List<RootCharacter> GetNewRootUnitInSphere(float searchArea, Vector3 searchPoint, List<RootCharacter> ignore, int maxNumTargets)
    {
        List<RootCharacter> targetList = new List<RootCharacter>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea, 1 << 8 | 1 << 12);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootCharacter)) && c.GetComponent<RootCharacter>().isAlive && !ignore.Contains(c.GetComponent<RootCharacter>()))
                targetList.Add(c.GetComponent<RootCharacter>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static List<RootCharacter> GetNewEnemyRootUnitInSphere(float searchArea, Vector3 searchPoint, List<RootCharacter> ignore, int maxNumTargets, int team)
    {
        List<RootCharacter> targetList = new List<RootCharacter>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea, 1 << 8 | 1 << 12);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootCharacter)) && c.GetComponent<RootCharacter>().isAlive && !ignore.Contains(c.GetComponent<RootCharacter>()) && c.GetComponent<RootCharacter>().team != team)
                targetList.Add(c.GetComponent<RootCharacter>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static List<RootCharacter> GetNewEnemyRootUnitInCapsule(Vector3 startPoint, Vector3 endPoint, float width, List<RootCharacter> ignore, int maxNumTargets, int team)
    {
        List<RootCharacter> targetList = new List<RootCharacter>();
        Collider[] collisionCapsule;
        Collider[] orderedCollisionSphere;

        collisionCapsule = Physics.OverlapCapsule(startPoint, endPoint, width, 1 << 8 | 1 << 12);
        //Debug.DrawLine(startPoint, endPoint, Color.red, .2f);
        //Debug.DrawLine((startPoint + endPoint) / 2, ((startPoint + endPoint) / 2) + new Vector3(width, 0, 0), Color.blue, .2f);
        //Debug.DrawLine((startPoint + endPoint) / 2, ((startPoint + endPoint) / 2) + new Vector3(-width, 0, 0), Color.blue, .2f);
        //Debug.DrawLine((startPoint + endPoint) / 2, ((startPoint + endPoint) / 2) + new Vector3(0, 0, width), Color.blue, .2f);
        //Debug.DrawLine((startPoint + endPoint) / 2, ((startPoint + endPoint) / 2) + new Vector3(0, 0, -width), Color.blue, .2f);
        orderedCollisionSphere = collisionCapsule.OrderBy(x => (startPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootCharacter)) && c.GetComponent<RootCharacter>().isAlive && !ignore.Contains(c.GetComponent<RootCharacter>()) && c.GetComponent<RootCharacter>().team != team)
                targetList.Add(c.GetComponent<RootCharacter>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static PlayerCharacterUnit GetInAreaPlayer(float searchArea, Vector3 searchPoint)
    {
        if (Vector3.Distance(searchPoint, PlayerCharacterUnit.player.transform.position) < searchArea)
            return PlayerCharacterUnit.player;
        else
            return null;
    }

    public static int GetTeam(Guid guid)
    {
        foreach (RootCharacter unit in GW_listOfAllUnits)
        {
            if (Guid.Equals(unit.unitID, guid))
            {
                return unit.team;
            }
        }

        foreach (HazardBase unit in GW_listOfHazards)
        {
            if (Guid.Equals(unit.unitID, guid))
            {
                return unit.team;
            }
        }

        return 0;
    }

    public static RootCharacter GetUnitByID(Guid guid)
    {
        foreach (RootCharacter unit in GW_listOfAllUnits)
        {
            if (Guid.Equals(unit.unitID, guid))
            {
                return unit;
            }
        }

        return null;
    }

    public static void LearnAllRunes()
    {
        List<FormRune> newForms = new List<FormRune>();
        List<SchoolRune> newSchools = new List<SchoolRune>();
        List<CastModeRune> newCastModes = new List<CastModeRune>();
        List<EffectRune> newEffectRunes = new List<EffectRune>();
        //Forms
        newForms.Add(new FormRune_Arc());
        newForms.Add(new FormRune_Aura());
        newForms.Add(new FormRune_Burst());
        newForms.Add(new FormRune_Command());
        newForms.Add(new FormRune_Lance());
        newForms.Add(new FormRune_Nova());
        newForms.Add(new FormRune_Orb());
        newForms.Add(new FormRune_Point());
        newForms.Add(new FormRune_SelfCast());
        newForms.Add(new FormRune_Strike());
        newForms.Add(new FormRune_Wave());
        newForms.Add(new FormRune_Weapon());
        newForms.Add(new FormRune_Zone());
        //Schools
        newSchools.Add(new SchoolRune_Air());
        newSchools.Add(new SchoolRune_Arcane());
        newSchools.Add(new SchoolRune_Astral());
        newSchools.Add(new SchoolRune_Earth());
        newSchools.Add(new SchoolRune_Electricity());
        newSchools.Add(new SchoolRune_Ethereal());
        newSchools.Add(new SchoolRune_Fire());
        newSchools.Add(new SchoolRune_Ice());
        newSchools.Add(new SchoolRune_Kinetic());
        newSchools.Add(new SchoolRune_Life());
        newSchools.Add(new SchoolRune_Water());
        //Cast Modes
        newCastModes.Add(new CastModeRune_Attack());
        newCastModes.Add(new CastModeRune_CastTime());
        newCastModes.Add(new CastModeRune_Channel());
        newCastModes.Add(new CastModeRune_Charge());
        newCastModes.Add(new CastModeRune_Reserve());
        //Effects
        foreach (string d in Directory.GetDirectories("Assets/Scripts/Abilities/Runes/Effects"))
        {
            foreach (string f in Directory.GetFiles(d))
            {
                if (!f.Contains(".meta"))
                {
                    var dir = f.Split('\\').Last().Split('.').First();
                    var rune = (EffectRune)Activator.CreateInstance(Type.GetType(dir));
                    rune.runeName = dir;
                    newEffectRunes.Add(rune);
                }
            }
        }


        PlayerCharacterUnit.player.knownRunes.AddRange(newForms);
        PlayerCharacterUnit.player.knownRunes.AddRange(newSchools);
        PlayerCharacterUnit.player.knownRunes.AddRange(newCastModes);
        PlayerCharacterUnit.player.knownRunes.AddRange(newEffectRunes);
        UIManager.main.abilityRuneSheet.AddFormSlot(newForms);
        UIManager.main.abilityRuneSheet.AddSchoolSlot(newSchools);
        UIManager.main.abilityRuneSheet.AddCastModeSlot(newCastModes);
        UIManager.main.abilityRuneSheet.AddEffectSlot(newEffectRunes);
    }
}