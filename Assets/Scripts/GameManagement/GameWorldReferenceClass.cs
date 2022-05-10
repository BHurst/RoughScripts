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

    public static PlayerCharacterUnit GW_Player;
    public static Camera GW_PlayerCamera;
    public EnemyManager enemyManager;
    public static List<RootUnit> GW_listOfAllUnits = new List<RootUnit>();
    public static List<WorldItem> GW_listOfItems = new List<WorldItem>();
    public static List<WorldObject> GW_listOfObjects = new List<WorldObject>();
    public static GameObject respawnPoint;
    public static CharacterPanelScripts GW_CharacterPanel;

    public int GWS_difficultyMod;
    public static float inputBuffer = .5f;

    private void Start()
    {
        respawnPoint = GameObject.Find("Respawn");
        GW_Player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        GW_PlayerCamera = Camera.main;
        GW_CharacterPanel = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void Respawn()
    {
        GW_Player.animator.Play("Idle");
        GW_Player.transform.position = respawnPoint.transform.position;
        GW_Player.unitBody.velocity = new Vector3(0, 0, 0);
        GW_Player.activeStatuses.Clear();
        GW_Player.StopCast();
        GW_Player.totalStats.Health_Current.value = GW_Player.totalStats.Health_Max.value;
        GW_Player.totalStats.Mana_Current.value = GW_Player.totalStats.Mana_Max.value;
        GW_Player.unitAbilityCharges.RefillCharges();
        GW_Player.isAlive = true;
    }

    public static void CreateWorldAbility(RootUnit target, RootUnit owner, WorldAbility worldAbility, int numberOfCopies)
    {
        List<RootUnit> targets = GetNewEnemyRootUnitInSphere(10, worldAbility.transform.position, worldAbility.previousTargets, worldAbility.wFormRune.formMaxTargets, owner.team);

        for (int i = 0; i < numberOfCopies && i < targets.Count; i++)
        {
            GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", worldAbility.wFormRune.formRuneType))) as GameObject;
            GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", worldAbility.wFormRune.formRuneType, worldAbility.wSchoolRune.schoolRuneType))) as GameObject;
            particles.transform.SetParent(abilityResult.transform);
            WorldAbility newWorldAbility = abilityResult.GetComponent<WorldAbility>();
            newWorldAbility.Construct(worldAbility, owner.unitID);
            newWorldAbility.targetPreference = targets[i].transform;
            newWorldAbility.previousTargets.Add(worldAbility.previousTargets.LastOrDefault());
            newWorldAbility.isTriggered = true;
            abilityResult.transform.position = worldAbility.transform.position;
        }
    }

    public static List<RootUnit> GetNewRootUnitInSphere(float searchArea, Vector3 searchPoint, List<RootUnit> ignore, int maxNumTargets)
    {
        List<RootUnit> targetList = new List<RootUnit>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea, 1 << 8 | 1 << 12);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootUnit)) && c.GetComponent<RootUnit>().isAlive && !ignore.Contains(c.GetComponent<RootUnit>()))
                targetList.Add(c.GetComponent<RootUnit>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static List<RootUnit> GetNewEnemyRootUnitInSphere(float searchArea, Vector3 searchPoint, List<RootUnit> ignore, int maxNumTargets, int team)
    {
        List<RootUnit> targetList = new List<RootUnit>();
        Collider[] collisionSphere;
        Collider[] orderedCollisionSphere;

        collisionSphere = Physics.OverlapSphere(searchPoint, searchArea, 1 << 8 | 1 << 12);

        orderedCollisionSphere = collisionSphere.OrderBy(x => (searchPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootUnit)) && c.GetComponent<RootUnit>().isAlive && !ignore.Contains(c.GetComponent<RootUnit>()) && c.GetComponent<RootUnit>().team != team)
                targetList.Add(c.GetComponent<RootUnit>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static List<RootUnit> GetNewEnemyRootUnitInCapsule(Vector3 startPoint, Vector3 endPoint, float width, List<RootUnit> ignore, int maxNumTargets, int team)
    {
        List<RootUnit> targetList = new List<RootUnit>();
        Collider[] collisionCapsule;
        Collider[] orderedCollisionSphere;

        collisionCapsule = Physics.OverlapCapsule(startPoint, startPoint + endPoint * width, width / 10, 1 << 8 | 1 << 12);

        orderedCollisionSphere = collisionCapsule.OrderBy(x => (startPoint - x.transform.position).sqrMagnitude).ToArray();

        foreach (Collider c in orderedCollisionSphere)
        {
            if (c.GetComponent(typeof(RootUnit)) && c.GetComponent<RootUnit>().isAlive && !ignore.Contains(c.GetComponent<RootUnit>()) && c.GetComponent<RootUnit>().team != team)
                targetList.Add(c.GetComponent<RootUnit>());

            if (targetList.Count >= maxNumTargets)
                break;
        }

        return targetList;
    }

    public static PlayerCharacterUnit GetInAreaPlayer(float searchArea, Vector3 searchPoint)
    {
        if (Vector3.Distance(searchPoint, GW_Player.transform.position) < searchArea)
            return GW_Player;
        else
            return null;
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

    public static void LearnAllRunes()
    {
        List<FormRune> newForms = new List<FormRune>();
        List<SchoolRune> newSchools = new List<SchoolRune>();
        List<CastModeRune> newCastModes = new List<CastModeRune>();
        List<EffectRune> newEffectRunes = new List<EffectRune>();
        //Forms
        newForms.Add(new FormRune_Arc());
        newForms.Add(new FormRune_Aura());
        newForms.Add(new FormRune_Beam());
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
        newCastModes.Add(new CastModeRune_Charges());
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


        GW_Player.knownRunes.AddRange(newForms);
        GW_Player.knownRunes.AddRange(newSchools);
        GW_Player.knownRunes.AddRange(newCastModes);
        GW_Player.knownRunes.AddRange(newEffectRunes);
        GW_CharacterPanel.abilityRuneSheet.AddSlot(newForms);
        GW_CharacterPanel.abilityRuneSheet.AddSlot(newSchools);
        GW_CharacterPanel.abilityRuneSheet.AddSlot(newCastModes);
        GW_CharacterPanel.abilityRuneSheet.AddSlot(newEffectRunes);
    }
}