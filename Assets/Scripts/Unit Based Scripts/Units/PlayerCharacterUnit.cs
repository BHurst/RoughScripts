using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootUnit
{
    public CastBar castBar;
    public GameObject selectedTargetHighlight;
    public List<GameObject> buffIcons = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            AbilitySlot newTempSlot = new AbilitySlot() { slotIndex = i };
            hotbarAbilities.Add(newTempSlot);
        }

        PlayerUnitStart();
    }

    public void PlayerUnitStart()
    {
        CreateInitial();
        //availableAbilities[0].stats.abilityKeywords.Add(KeywordDictionary.Area());
        charInventory.AddItem(ItemFactory.CreateGoreHead());
        charInventory.AddItem(ItemFactory.CreateDashSword());
        charInventory.AddItem(ItemFactory.CreateWizardRobe());
        charInventory.AddItem(ItemFactory.CreateMindOfMatterAmulet());
        HotbarPane.FillHotbar(this);
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = UnityEngine.Random.Range(0, int.MaxValue);
    }

    new public void CastingTimeCheck()
    {
        if (abilityBeingCast != null)
        {
            if (moving && abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Stationary))
            {
                StopCast();
                castBar.CastUpdate(0);
                return;
            }

            if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Channel))
            {
                currentCastingTime += Time.deltaTime;
                if ((currentCastingTime > abilityBeingCast.stats.abilityBaseInterval / totalStats.BonusCastSpeedPercent))
                {
                    if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
                    {
                        SpawnAbility(abilityBeingCast);
                        currentCastingTime -= abilityBeingCast.stats.abilityBaseInterval / totalStats.BonusAttackSpeedPercent;
                        //queuedAbility.stats.abilityBaseCastTime -= queuedAbility.stats.abilityBaseInterval / totalStats.BonusAttackSpeedPercent;
                    }
                    else if (abilityBeingCast.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
                    {
                        SpawnAbility(abilityBeingCast);
                        currentCastingTime -= abilityBeingCast.stats.abilityBaseInterval / totalStats.BonusCastSpeedPercent;
                        //queuedAbility.stats.abilityBaseCastTime -= queuedAbility.stats.abilityBaseInterval / totalStats.BonusCastSpeedPercent;
                    }
                    if (abilityBeingCast.stats.abilityBaseCastTime <= 0)
                        StopCast();
                }
            }
            else
            {
                currentCastingTime += Time.deltaTime;
                castBar.CastUpdate(currentCastingTime / (abilityBeingCast.stats.abilityBaseCastTime / totalStats.BonusCastSpeedPercent));
                if (currentCastingTime >= abilityBeingCast.stats.abilityBaseCastTime / totalStats.BonusCastSpeedPercent)
                {
                    var charAnimator = GetComponent<Animator>();
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
                        abilitiesOnCooldown.AddCooldown(abilityBeingCast.abilityID, abilityBeingCast.stats.abilityBaseCooldown);
                        SpawnAbility(abilityBeingCast);
                    }
                    currentCastingTime = 0;
                    abilityBeingCast = null;
                }
            }
        }
    }

    public void PlayerKill()
    {
        Kill();
    }

    public void DeathCheck()
    {
        if (unitHealth <= 0)
        {
            Kill();
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        DeathCheck();
        if (isAlive == true)
        {
            MovementCheck();
            CastingTimeCheck();
            if (state.Stunned == false)
            {

            }
            ResolveStatusEffects();
            abilitiesOnCooldown.UpdateCooldowns();
            ActionCD();
        }
    }
}