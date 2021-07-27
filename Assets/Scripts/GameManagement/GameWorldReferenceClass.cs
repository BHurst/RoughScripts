using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.IO;

[Serializable]
public class GameWorldReferenceClass : MonoBehaviour
{

    public static PlayerCharacterUnit GW_Player;
    public static Camera GW_PlayerCamera;
    public static List<RootUnit> GW_listOfNpcs = new List<RootUnit>();
    public static List<RootUnit> GW_listOfAllUnits = new List<RootUnit>();
    public static List<WorldItem> GW_listOfItems = new List<WorldItem>();
    public static List<WorldObject> GW_listOfObjects = new List<WorldObject>();
    public static int PartyMoney = 0;
    public static CharacterPanelScripts GW_CharacterPanel;

    public int GWS_difficultyMod;

    private void Start()
    {
        GW_Player = GameObject.Find("Player").GetComponent<PlayerCharacterUnit>();
        GW_PlayerCamera = Camera.main;
        UnityEngine.Object[] tempAbilityList = Resources.LoadAll("SO/Abilities", typeof(ScriptableObject));
        UnityEngine.Object[] tempStatusList = Resources.LoadAll("SO/Statuses", typeof(ScriptableObject));
        GW_CharacterPanel = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void CreateWorldAbility(RootUnit target, RootUnit owner, WorldAbility worldAbility, int numberOfCopies)
    {
        List<RootUnit> targets = GetInAreaRootUnit(10, worldAbility.transform.position, worldAbility.previousTargets);

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

    public static List<RootUnit> GetInAreaRootUnit(float searchArea, Vector3 searchPoint, List<RootUnit> ignore)
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
        }

        return targetList;
    }

    public static PlayerCharacterUnit GetInAreaPlayer(float searchArea, Vector3 searchPoint)
    {
        PlayerCharacterUnit player = null;
        var search = Physics.OverlapSphere(searchPoint, searchArea, 1 << 12).FirstOrDefault();
        if (search != null)
            player = search.GetComponent<PlayerCharacterUnit>();

        if (player != null)
            return player;
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
        newForms.Add(new FormRune() { runeName = "Arc", formRuneType = Rune.FormRuneTag.Arc });
        newForms.Add(new FormRune() { runeName = "Aura", formRuneType = Rune.FormRuneTag.Aura });
        newForms.Add(new FormRune() { runeName = "Beam", formRuneType = Rune.FormRuneTag.Beam });
        newForms.Add(new FormRune() { runeName = "Command", formRuneType = Rune.FormRuneTag.Command });
        newForms.Add(new FormRune() { runeName = "Lance", formRuneType = Rune.FormRuneTag.Lance });
        newForms.Add(new FormRune() { runeName = "Nova", formRuneType = Rune.FormRuneTag.Nova });
        newForms.Add(new FormRune() { runeName = "Orb", formRuneType = Rune.FormRuneTag.Orb });
        newForms.Add(new FormRune() { runeName = "Point", formRuneType = Rune.FormRuneTag.Point });
        newForms.Add(new FormRune() { runeName = "SelfCast", formRuneType = Rune.FormRuneTag.SelfCast });
        newForms.Add(new FormRune() { runeName = "Strike", formRuneType = Rune.FormRuneTag.Strike });
        newForms.Add(new FormRune() { runeName = "Wave", formRuneType = Rune.FormRuneTag.Wave });
        newForms.Add(new FormRune() { runeName = "Weapon", formRuneType = Rune.FormRuneTag.Weapon });
        newForms.Add(new FormRune() { runeName = "Zone", formRuneType = Rune.FormRuneTag.Zone });
        //Schools
        newSchools.Add(new SchoolRune() { runeName = "Air", schoolRuneType = Rune.SchoolRuneTag.Air });
        newSchools.Add(new SchoolRune() { runeName = "Arcane", schoolRuneType = Rune.SchoolRuneTag.Arcane });
        newSchools.Add(new SchoolRune() { runeName = "Astral", schoolRuneType = Rune.SchoolRuneTag.Astral });
        newSchools.Add(new SchoolRune() { runeName = "Electricity", schoolRuneType = Rune.SchoolRuneTag.Electricity });
        newSchools.Add(new SchoolRune() { runeName = "Ethereal", schoolRuneType = Rune.SchoolRuneTag.Ethereal });
        newSchools.Add(new SchoolRune() { runeName = "Ice", schoolRuneType = Rune.SchoolRuneTag.Ice });
        newSchools.Add(new SchoolRune() { runeName = "Fire", schoolRuneType = Rune.SchoolRuneTag.Fire });
        newSchools.Add(new SchoolRune() { runeName = "Kinetic", schoolRuneType = Rune.SchoolRuneTag.Kinetic });
        newSchools.Add(new SchoolRune() { runeName = "Nature", schoolRuneType = Rune.SchoolRuneTag.Nature });
        newSchools.Add(new SchoolRune() { runeName = "Water", schoolRuneType = Rune.SchoolRuneTag.Water });
        //Cast Modes
        newCastModes.Add(new CastModeRune() { runeName = "Attack", castModeRuneType = Rune.CastModeRuneTag.Attack });
        newCastModes.Add(new CastModeRune() { runeName = "CastTime", castModeRuneType = Rune.CastModeRuneTag.CastTime });
        newCastModes.Add(new CastModeRune() { runeName = "Channel", castModeRuneType = Rune.CastModeRuneTag.Channel });
        newCastModes.Add(new CastModeRune() { runeName = "Instant", castModeRuneType = Rune.CastModeRuneTag.Instant });
        //Effects
        foreach (string d in Directory.GetDirectories("Assets/Scripts/Abilities/Runes/Effects"))
        {
            foreach (string f in Directory.GetFiles(d))
            {
                if(!f.Contains(".meta"))
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
        GW_CharacterPanel.abilityRunePane.AddSlot(newForms);
        GW_CharacterPanel.abilityRunePane.AddSlot(newSchools);
        GW_CharacterPanel.abilityRunePane.AddSlot(newCastModes);
        GW_CharacterPanel.abilityRunePane.AddSlot(newEffectRunes);
    }
}