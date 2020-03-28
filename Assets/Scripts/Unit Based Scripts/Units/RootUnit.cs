using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUnit : MonoBehaviour
{
    public int unitID = 0;
    public Vector3 location;
    public int team = 2;
    public float unitHealth = 100;
    public float unitMaxHealth = 100;
    public float unitMana = 100;
    public float unitMaxMana = 100;
    public float unitMaxSingleManaExpenditure = 100;
    public string unitName = "DummyName";
    public bool droppedItems = false;
    public bool inCombat = false;
    public bool hasSpeech = false;
    public string hostility; //Make enum
    public bool isAlive = true;
    public bool moving = false;
    public float currentCastingTime = 0;
    public float talkRange = 3.2f;
    public float attackTimer = 0;
    public int size = 3;
    public bool attackable = true;
    public RootAbility abilityBeingCast;
    public Transform primarySpellCastLocation;
    public float waistHight = 1f;
    public CharacterInventory charInventory = new CharacterInventory();
    public List<RootAbility> availableAbilities = new List<RootAbility>();
    public List<AbilitySlot> hotbarAbilities = new List<AbilitySlot>();
    public List<StatusTimer> currentStatusEffects = new List<StatusTimer>();
    public UnitStats totalStats = new UnitStats();
    public UnitStats attributeStats = new UnitStats();
    public UnitStats equipmentStats = new UnitStats();
    public UnitStats talentStats = new UnitStats();
    public UnitStats buffStats = new UnitStats();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll doll = new EquipmentDoll();
    public CharacterClass cClass = new CharacterClass();
    public TalentCollection cTalents = new TalentCollection();
    public CharacterLevel level = new CharacterLevel();
    public Cooldowns abilitiesOnCooldown = new Cooldowns();
    public float timer;
    public float actionCooldown = 0;
    public float globalActionCooldown = 0;

    public void RefreshState()
    {
        if (currentStatusEffects.Count == 0)
        {
            state.ClearState();

            if (GetComponent<Light>() == true)
                Destroy(transform.GetComponent<Light>());
        }

        //foreach (RootStatus status in currentStatusEffects)
        //{
        //    if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Fire) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //    {
        //    }
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Nature) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Poisoned = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Water) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Wet = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Air) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Electrified = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Physical) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Bleeding = true;
        //    else if (status.AbilityTags.Contains(AbilityTags.AbilityTag.Stun))
        //    {
        //        state.Stunned = true;
        //        attackTimer = 0;
        //        queuedAbility = null;
        //    }
        //    else if (status.AbilityTags.Contains(AbilityTags.AbilityTag.Root))
        //        state.Rooted = true;
        //}


    }

    public void RefreshStats()
    {
        attributeStats.ResetStats();
        attributeStats.CalculateStatBonuses(this);
        equipmentStats.RefreshAllStats();
        doll.DetermineWeaponStats();
        talentStats.RefreshAllStats();
        buffStats.RefreshAllStats();
        totalStats.RefreshAllStats();

        totalStats.AttackDamageMin = attributeStats.AttackDamageMin + equipmentStats.AttackDamageMin + talentStats.AttackDamageMin + buffStats.AttackDamageMin;
        totalStats.AttackDamageMax = attributeStats.AttackDamageMax + equipmentStats.AttackDamageMax + talentStats.AttackDamageMax + buffStats.AttackDamageMax;
        totalStats.BonusAttackDamageFlat = attributeStats.BonusAttackDamageFlat + equipmentStats.BonusAttackDamageFlat + talentStats.BonusAttackDamageFlat + buffStats.BonusAttackDamageFlat;
        totalStats.BonusAttackDamagePercent = attributeStats.BonusAttackDamagePercent * equipmentStats.BonusAttackDamagePercent * talentStats.BonusAttackDamagePercent * buffStats.BonusAttackDamagePercent;
        totalStats.BonusSpellDamageFlat = attributeStats.BonusSpellDamageFlat + equipmentStats.BonusSpellDamageFlat + talentStats.BonusSpellDamageFlat + buffStats.BonusSpellDamageFlat;
        totalStats.BonusSpellDamagePercent = attributeStats.BonusSpellDamagePercent * equipmentStats.BonusSpellDamagePercent * talentStats.BonusSpellDamagePercent * buffStats.BonusSpellDamagePercent;
        totalStats.BonusDamagePercent = attributeStats.BonusDamagePercent * equipmentStats.BonusDamagePercent * talentStats.BonusDamagePercent * buffStats.BonusDamagePercent;
        totalStats.BonusHealFlat = attributeStats.BonusHealFlat + equipmentStats.BonusHealFlat + talentStats.BonusHealFlat + buffStats.BonusHealFlat;
        totalStats.BonusHealPercent = attributeStats.BonusHealPercent * equipmentStats.BonusHealPercent * talentStats.BonusHealPercent * buffStats.BonusHealPercent;
        totalStats.AttackSpeed = equipmentStats.AttackSpeed;
        totalStats.BonusAttackSpeedPercent = attributeStats.BonusAttackSpeedPercent * equipmentStats.BonusAttackSpeedPercent * talentStats.BonusAttackSpeedPercent * buffStats.BonusAttackSpeedPercent;
        totalStats.BonusCastSpeedPercent = attributeStats.BonusCastSpeedPercent * equipmentStats.BonusCastSpeedPercent * talentStats.BonusCastSpeedPercent * buffStats.BonusCastSpeedPercent;
        totalStats.BonusMoveSpeedFlat = attributeStats.BonusMoveSpeedFlat + equipmentStats.BonusMoveSpeedFlat + talentStats.BonusMoveSpeedFlat + buffStats.BonusMoveSpeedFlat;
        totalStats.BonusMoveSpeedPercent = attributeStats.BonusMoveSpeedPercent * equipmentStats.BonusMoveSpeedPercent * talentStats.BonusMoveSpeedPercent * buffStats.BonusMoveSpeedPercent;
        totalStats.AllResistance = attributeStats.AllResistance * equipmentStats.AllResistance * talentStats.AllResistance * buffStats.AllResistance;
        totalStats.Defence = attributeStats.Defence * equipmentStats.Defence * talentStats.Defence * buffStats.Defence;
        totalStats.AllDamageReduction = attributeStats.AllDamageReduction * equipmentStats.AllDamageReduction * talentStats.AllDamageReduction * buffStats.AllDamageReduction;
        totalStats.CooldownReduction = attributeStats.CooldownReduction * equipmentStats.CooldownReduction * talentStats.CooldownReduction * buffStats.CooldownReduction;
        totalStats.PhysicalCritChance = attributeStats.PhysicalCritChance + equipmentStats.PhysicalCritChance + talentStats.PhysicalCritChance + buffStats.PhysicalCritChance;
        totalStats.PhysicalCritDamage = (attributeStats.PhysicalCritDamage + equipmentStats.PhysicalCritDamage + talentStats.PhysicalCritDamage + buffStats.PhysicalCritDamage) - 4.5f;//base crit bonus of three of the attribute lists
        totalStats.SpellCritChance = attributeStats.SpellCritChance + equipmentStats.SpellCritChance + talentStats.SpellCritChance + buffStats.SpellCritChance;
        totalStats.SpellCritDamage = (attributeStats.SpellCritDamage + equipmentStats.SpellCritDamage + talentStats.SpellCritDamage + buffStats.SpellCritDamage) - 4.5f;//base crit bonus of three of the attribute lists

        RefreshState();
    }

    public void MovementCheck()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude >= totalStats.MoveSpeed / 5)
            moving = true;
        else
            moving = false;
    }

    bool PickupRangeCheck(WorldItem currentItemTarget)
    {
        if (Vector3.Distance(currentItemTarget.transform.position, this.transform.position) <= currentItemTarget.interactDistance)
            return true;
        else
            return false;
    }

    public bool InteractRangeCheck(WorldObject currentInteractTarget)
    {
        if (Vector3.Distance(currentInteractTarget.transform.position, this.transform.position) <= currentInteractTarget.distanceToBeInteracted)
            return true;
        else
            return false;
    }

    public void ApplyStatusEffect(List<RootStatus> statusEffects)
    {
        int checkStatus = 0;
        float statusOccurence = UnityEngine.Random.Range(0, 100);

        foreach (RootStatus status in statusEffects)
        {
            checkStatus = currentStatusEffects.FindIndex(s => s.status.statusID == status.statusID);
            if ((status.statusBaseStatusChance >= statusOccurence && checkStatus == -1) || status.stackable)
            {
                StatusTimer rS = new StatusTimer();
                rS.status = status;
                rS.maxDuration = status.statusBaseDuration;
                rS.currentDuration = status.statusBaseDuration;
                currentStatusEffects.Add(rS);
                foreach (Modifier modifier in status.statusStatsToModify)
                {
                    buffStats.IncreaseStat(modifier.Mod, modifier.ModAmount);
                    RefreshStats();
                }
            }
            else if (checkStatus >= 0 && status.multiUnitStackable == false)
            {
                currentStatusEffects[checkStatus].status.statusBaseDuration = status.statusBaseDuration;
            }
            else if (checkStatus >= 0 && status.multiUnitStackable == true)
            {
                if ((currentStatusEffects[checkStatus].currentDuration < currentStatusEffects[checkStatus].maxDuration) || (currentStatusEffects[checkStatus].status.statusHealthChangePerSecond < status.statusHealthChangePerSecond))
                {
                    StatusTimer rS = new StatusTimer();
                    rS.status = status;
                    currentStatusEffects[checkStatus] = rS;
                }
            }
            if (GetComponent<PlayerCharacterUnit>())
            {
                var temp = Instantiate(Resources.Load("Prefabs/UIComponents/Buff")) as GameObject;
                temp.GetComponent<BuffDisplayIcon>().buffDuration = status.statusBaseDuration;
                temp.GetComponent<BuffDisplayIcon>().buffSource = status.statusID;
                temp.transform.SetParent(GameObject.Find("BuffContent").transform);

                GetComponent<PlayerCharacterUnit>().buffIcons.Add(temp);
            }

        }
    }

    public bool ResolveHit(RootWorldAbility abilityToResolve)
    {
        DamageHitInfo hitToTake = new DamageHitInfo();
        bool unitAlive = true;
        if (isAlive == true && ((team != abilityToResolve.abilityOwner.GetComponent<RootUnit>().team)))
        {
            if (abilityToResolve.stats.abilityDamageComponents.Count > 0)
            {
                foreach (Damage d in abilityToResolve.stats.abilityDamageComponents)
                    hitToTake = DamageManager.CalculateDamage(abilityToResolve.abilityOwner.GetComponent<RootUnit>(), this, abilityToResolve);

                if (abilityToResolve.stats.abilityTags.Contains(AbilityTags.AbilityTag.Damage))
                {
                    unitHealth -= hitToTake.damageToDeal;
                    if (unitHealth <= 0)
                        unitAlive = false;
                    CharacterPanelScripts.CreateDamageText((int)hitToTake.damageToDeal, hitToTake.hitType, this.transform.position);
                }
                else if (abilityToResolve.stats.abilityTags.Contains(AbilityTags.AbilityTag.Heal))
                {
                    unitHealth += hitToTake.damageToDeal;
                    if (unitHealth > unitMaxHealth)
                        unitHealth = unitMaxHealth;
                    CharacterPanelScripts.CreateHealText((int)hitToTake.damageToDeal, hitToTake.hitType, this.transform.position);
                }

                ResolveStatusCharges(RootStatus.ChargesRemovedBy.TakeDamage);
            }
            else
            {
                CharacterPanelScripts.CreatePopupText(abilityToResolve.stats.abilityName, this.transform.position);
            }

            if (abilityToResolve.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
                ResolveStatusCharges(RootStatus.ChargesRemovedBy.TakeAttack);
            if (abilityToResolve.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
                ResolveStatusCharges(RootStatus.ChargesRemovedBy.TakeSpell);
        }

        if (!unitAlive)
            return true;
        else
            return false;
    }

    public void ResolveStatusEffects()
    {
        List<int> expiringStatuses = new List<int>();
        foreach (StatusTimer activeStatus in currentStatusEffects)
        {
            activeStatus.currentDuration -= Time.deltaTime;
            if (activeStatus.currentDuration <= 0)
            {

                activeStatus.currentDuration = 0;
                foreach (Modifier modifier in activeStatus.status.statusStatsToModify)
                {
                    buffStats.DecreaseStat(modifier.Mod, modifier.ModAmount);
                    RefreshStats();
                }
                expiringStatuses.Add(activeStatus.status.statusID);
            }
            else
            {
                float healthChange = 0;
                if (activeStatus.status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
                {
                    healthChange += activeStatus.status.statusHealthChangePerSecond * Time.deltaTime;
                }
                else if (activeStatus.status.AbilityTags.Contains(AbilityTags.AbilityTag.Heal))
                {
                    healthChange -= activeStatus.status.statusHealthChangePerSecond * Time.deltaTime;
                }
                else
                {
                    activeStatus.status.ActivateEffect();
                }

                unitHealth -= healthChange;
            }
        }

        foreach (int statusToRemove in expiringStatuses)
        {
            if (GetComponent<PlayerCharacterUnit>())
            {
                foreach (var thing in GetComponent<PlayerCharacterUnit>().buffIcons)
                {
                    if (thing.GetComponent<BuffDisplayIcon>().buffSource == statusToRemove)
                        Destroy(thing.gameObject);
                }
            }

            for (int i = currentStatusEffects.Count - 1; i >= 0; i--)
            {
                if (currentStatusEffects[i].status.statusID == statusToRemove)
                    currentStatusEffects.Remove(currentStatusEffects[i]);
            }
        }
        expiringStatuses.Clear();
    }

    public void ResolveStatusCharges(RootStatus.ChargesRemovedBy Occurence)
    {
        List<int> expiringStatuses = new List<int>();
        foreach (StatusTimer activeStatus in currentStatusEffects)
        {
            if (activeStatus.status.AbilityTags.Contains(AbilityTags.AbilityTag.Charges) && activeStatus.status.statusChargesRemoval.Equals(Occurence))
            {
                activeStatus.currentCharges--;
                if (activeStatus.currentCharges <= 0)
                {
                    foreach (Modifier modifier in activeStatus.status.statusStatsToModify)
                    {
                        buffStats.DecreaseStat(modifier.Mod, modifier.ModAmount);
                    }
                    RefreshStats();
                    expiringStatuses.Add(activeStatus.status.statusID);
                }
            }
        }

        foreach (int statusToRemove in expiringStatuses)
        {
            if (GetComponent<PlayerCharacterUnit>())
            {
                foreach (var thing in GetComponent<PlayerCharacterUnit>().buffIcons)
                {
                    if (thing.GetComponent<BuffDisplayIcon>().buffSource == statusToRemove)
                        Destroy(thing.gameObject);
                }
            }

            for (int i = currentStatusEffects.Count - 1; i >= 0; i--)
            {
                if (currentStatusEffects[i].status.statusID == statusToRemove)
                {
                    currentStatusEffects.Remove(currentStatusEffects[i]);
                }
            }
        }
        expiringStatuses.Clear();
    }

    public void ResolveSizeCollision(RootUnit Char1, RootUnit Char2)
    {
        if (Char1.size > Char2.size)
        {
            Char2.GetComponent<Rigidbody>().velocity = Char1.transform.position - Char2.transform.position;
        }
        else if (Char1.size == Char2.size)
        {
            Char2.GetComponent<Rigidbody>().velocity = new Vector3(2000, 0, 0);
        }
    }

    public void CastingTimeCheck()
    {
        if (abilityBeingCast != null)
        {
            if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Channel))
            {
                currentCastingTime += Time.deltaTime;
                if (abilityBeingCast.stats.abilityBaseRangeMaximum == 0)
                {
                    if (currentCastingTime > abilityBeingCast.stats.abilityBaseInterval / totalStats.BonusCastSpeedPercent)
                    {
                        SpawnAbility(abilityBeingCast);

                        abilitiesOnCooldown.AddCooldown(abilityBeingCast.abilityID, abilityBeingCast.stats.abilityBaseCooldown);

                        currentCastingTime = 0;

                        //queuedAbility.stats.abilityBaseCastTime -= queuedAbility.stats.abilityBaseInterval / totalStats.BonusCastSpeedPercent;

                        if (abilityBeingCast.stats.abilityBaseCastTime <= 0 || abilityBeingCast.stats.abilityBaseCastTime < abilityBeingCast.stats.abilityBaseInterval)
                            StopCast();
                    }
                }
                else
                    StopCast();
            }
            else
            {
                currentCastingTime += Time.deltaTime;
                if (currentCastingTime >= abilityBeingCast.stats.abilityBaseCastTime / totalStats.BonusCastSpeedPercent)
                {
                    var charAnimator = GetComponent<Animator>();
                    abilityBeingCast = null;
                    currentCastingTime = 0;
                    if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
                    {
                        charAnimator.speed = totalStats.AttackSpeed * totalStats.BonusAttackSpeedPercent;
                        charAnimator.Play("WeaponSwing");
                    }
                    else if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
                    {
                        charAnimator.speed = totalStats.BonusCastSpeedPercent;
                        charAnimator.Play("RightHandCast");
                    }
                    if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
                        SpawnAbility(abilityBeingCast);
                    else
                    {
                        SpawnAbility(abilityBeingCast);
                        abilitiesOnCooldown.AddCooldown(abilityBeingCast.abilityID, abilityBeingCast.stats.abilityBaseCooldown);
                    }

                    abilityBeingCast = null;


                }
                else if (moving == true && abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Stationary))
                    StopCast();
            }
        }
    }

    public void CastCheck(RootAbility ability)
    {
        if(abilityBeingCast != null)
        {
            ErrorScript.DisplayError("Already casting something.");
        }
        else if (globalActionCooldown > 0 || actionCooldown > 0 || abilitiesOnCooldown.cooldowns.Exists(x => x.id == ability.abilityID))
        {
            ErrorScript.DisplayError("That ability is still on cooldown.");
        }
        else
        {
            RootAbility abilityToCast = GameWorldReferenceClass.GW_listOfAbilities.Find(x => x.abilityID == ability.abilityID);
            if (abilityToCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Stationary))
            {
                abilityBeingCast = abilityToCast;
            }
            else
            {
                if (!moving)
                {
                    abilityBeingCast = abilityToCast;
                }
            }
        }
    }

    public void SpawnAbility(RootAbility ability)
    {
        GameObject abilityResult = Instantiate(Resources.Load(ability.stats.abilityPrefabLocation)) as GameObject;
        if (ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
        {
            SpellWorldAbility newWorldSpell = abilityResult.GetComponent<SpellWorldAbility>();
            newWorldSpell.stats = ability.stats;
            newWorldSpell.abilityID = ability.abilityID;
            newWorldSpell.abilityOwner = this;
            newWorldSpell.ConsolidateKeywordBonuses();

            //foreach (AbilityModifierKeyword keyword in newWorldSpell.stats.abilityKeywords)
            //{
            //    foreach (AbilityTags.AbilityTag tag in keyword.abilityTags)
            //    {
            //        if (!newWorldSpell.stats.abilityTags.Contains(tag))
            //            newWorldSpell.stats.abilityTags.Add(tag);
            //    }

            //    foreach (Damage d in keyword.abilityDamageComponents)
            //        newWorldSpell.stats.abilityDamageComponents.Add(d);
            //}

            abilityResult.transform.position = primarySpellCastLocation.position;
            if (ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Local))
                abilityResult.transform.position = transform.position;

            //availableAbilities.Find(x => x.abilityID == ability.abilityID).stats.abilityCurrentCooldown = ability.stats.abilityBaseCooldown * totalStats.CooldownReduction;

            ResolveStatusCharges(RootStatus.ChargesRemovedBy.AnyAbility);
            if (ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
                ResolveStatusCharges(RootStatus.ChargesRemovedBy.CastSpell);
        }
        else if (ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
        {
            WeaponWorldAbility newWorldAttack = abilityResult.GetComponent<WeaponWorldAbility>();
            newWorldAttack.stats = ability.stats;
            newWorldAttack.abilityID = ability.abilityID;
            newWorldAttack.abilityOwner = this;
            newWorldAttack.ConsolidateKeywordBonuses();

            foreach (AbilityModifierKeyword keyword in newWorldAttack.stats.abilityKeywords)
            {
                foreach (AbilityTags.AbilityTag tag in keyword.abilityTags)
                {
                    if (!newWorldAttack.stats.abilityTags.Contains(tag))
                        newWorldAttack.stats.abilityTags.Add(tag);
                }

                foreach (Damage d in keyword.abilityDamageComponents)
                {
                    newWorldAttack.stats.abilityDamageComponents.Add(d);
                }
            }

            if (ability.stats.numberOfSpells == 1)
                abilityResult.transform.position = transform.position + transform.forward;
            else if (ability.stats.abilityBaseRangeMaximum == 0)
                abilityResult.transform.position = transform.position;

            RootAbility temp = availableAbilities.Find(x => x.abilityID == ability.abilityID);
            //temp.stats.abilityCurrentCooldown = temp.stats.abilityBaseCooldown * totalStats.CooldownReduction;

            ResolveStatusCharges(RootStatus.ChargesRemovedBy.AnyAbility);

            newWorldAttack.ownersWeapon = transform.Find("Hand").Find("Stick");

            if (doll.mainHand.hasItem)
            {
                newWorldAttack.abilityDuration = doll.mainHand.itemInSlot.iStats.equipment.weaponStats.activeFramesEnd / totalStats.BonusAttackSpeedPercent;
                newWorldAttack.activationStart = doll.mainHand.itemInSlot.iStats.equipment.weaponStats.activeFramesStart / totalStats.BonusAttackSpeedPercent;
                newWorldAttack.activationEnd = doll.mainHand.itemInSlot.iStats.equipment.weaponStats.activeFramesEnd / totalStats.BonusAttackSpeedPercent;
            }
            else
            {
                newWorldAttack.abilityDuration = 70 / 120 / totalStats.BonusAttackSpeedPercent;//Unarmed number placeholder
                newWorldAttack.activationStart = 30 / 120 / totalStats.BonusAttackSpeedPercent;
                newWorldAttack.activationEnd = 70 / 120 / totalStats.BonusAttackSpeedPercent;
            }

            foreach (RootStatus status in newWorldAttack.stats.Statuses)
            {
                if (status.AbilityTags.Contains(AbilityTags.AbilityTag.Attack))
                {
                    status.statusHealthChangePerSecond = Mathf.Round(((totalStats.AttackDamageMin + totalStats.AttackDamageMax) / 2) * status.statusWeaponModifier);
                }
            }

            if (ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
                ResolveStatusCharges(RootStatus.ChargesRemovedBy.CastAttack);
        }
    }

    public void Kill()
    {
        unitHealth = 0;
        isAlive = false;
        currentStatusEffects.Clear();
        state.ClearState();
        RefreshState();
        RefreshStats();
    }

    public void ActionCD()
    {
        if (actionCooldown >= 0)
            actionCooldown -= Time.deltaTime;

        if (globalActionCooldown >= 0)
            globalActionCooldown -= Time.deltaTime;
    }

    public void StopCast()
    {
        currentCastingTime = 0;
        abilityBeingCast = null;
    }
}