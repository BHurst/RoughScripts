﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStates
{
    public List<State_Bleed> BleedingEffects = new List<State_Bleed>();
    public bool Bleeding = false;
    float totalBleeding = 0;
    float bleedingValue = 0;

    public List<State_Burn> BurningEffects = new List<State_Burn>();
    public bool Burning = false;
    public float BurningBaseValue = 0;
    float highestBurning = 0;
    float burningValue = 0;

    public List<State_Decay> DecayingEffects = new List<State_Decay>();
    public bool Decaying = false;
    public float DecayingBaseValue = .0025f;
    float highestDecaying = 0;
    float decayingValue = 0;

    public bool Distorted = false;
    float totalDistortion = 0;
    float distortionValue = 0;

    public List<State_Frostbite> FrostbittenEffects = new List<State_Frostbite>();
    public bool Frostbitten = false;
    public float FrostbittenBaseValue = 0;
    float highestFrostbitten = 0;
    float frostbittenValue = 0;

    public bool Overcharged = false;
    float totalOvercharged = 0;

    public bool RimeGuard = false;
    public int rimeGuardCharges = 0;
    float totalRimeGuardProgress = 0;

    public List<State_SoulRot> SoulRottingEffects = new List<State_SoulRot>();
    public bool SoulRotting = false;
    float totalSoulRotting = 0;
    float soulRottingValue = 0;

    float totalHealthLoss = 0;
    float totalManaLoss = 0;

    public void ClearState()
    {
        BleedingEffects.Clear();
        Bleeding = false;
        BurningEffects.Clear();
        Burning = false;
        DecayingEffects.Clear();
        Decaying = false;
        totalDistortion = 0;
        FrostbittenEffects.Clear();
        Frostbitten = false;
        totalOvercharged = 0;
        Overcharged = false;
        RimeGuard = false;
        totalRimeGuardProgress = 0;
        rimeGuardCharges = 0;
        SoulRottingEffects.Clear();
        SoulRotting = false;
    }

    public void AddState(StateEffect specialStatus)
    {
        if (specialStatus is State_Bleed)
        {
            BleedingEffects.Add((State_Bleed)specialStatus);
            Bleeding = true;
        }
        else if (specialStatus is State_Burn)
        {
            BurningEffects.Add((State_Burn)specialStatus);
            Burning = true;
        }
        else if (specialStatus is State_Decay)
        {
            DecayingEffects.Add((State_Decay)specialStatus);
            Decaying = true;
        }
        else if(specialStatus is State_Distortion)
        {
            totalDistortion += specialStatus.snapshot.distortionStrength;
        }
        else if (specialStatus is State_Frostbite)
        {
            FrostbittenEffects.Add((State_Frostbite)specialStatus);
            Frostbitten = true;
        }
        else if (specialStatus is State_Overcharge)
        {
            totalOvercharged += specialStatus.snapshot.overchargeStrength;
        }
        else if (specialStatus is State_RimeGuard)
        {
            totalRimeGuardProgress += specialStatus.snapshot.rimeguardStrength;
        }
        else if (specialStatus is State_SoulRot)
        {
            SoulRottingEffects.Add((State_SoulRot)specialStatus);
            SoulRotting = true;
        }
    }

    public void RemoveFrostGuard(int chargesToRemove)
    {
        rimeGuardCharges = Mathf.Clamp(rimeGuardCharges - chargesToRemove, 0, 3);
        if (rimeGuardCharges == 0)
            RimeGuard = false;
    }

    public void StateTick(RootCharacter rootCharacter)
    {
        totalHealthLoss = 0;
        totalManaLoss = 0;

        if (Bleeding)
        {
            totalBleeding = 0;
            for (int i = BleedingEffects.Count - 1; i > -1; i--)
            {
                totalBleeding += BleedingEffects[i].snapshot.bleedStrength;
                BleedingEffects[i].currentDuration -= Time.deltaTime;

                if (BleedingEffects[i].currentDuration < 0)
                    BleedingEffects.RemoveAt(i);
            }

            bleedingValue = State_Bleed.bleedDamageRatio * totalBleeding * Time.deltaTime;
            bleedingValue /= (1 + rootCharacter.totalStats.Bleed_Resistance_AddPercent.value);
            totalHealthLoss += bleedingValue;

            if (BleedingEffects.Count == 0)
                Bleeding = false;
        }
        if (Burning)
        {
            highestBurning = 1;
            foreach (var burn in BurningEffects)
            {
                if (burn.snapshot.burnStrength > highestBurning)
                    highestBurning = burn.snapshot.burnStrength;
            }

            burningValue = rootCharacter.totalStats.Health_Max * (BurningBaseValue * highestBurning) * Time.deltaTime;
            burningValue /= (1 + rootCharacter.totalStats.Burn_Resistance_AddPercent.value);
            totalHealthLoss += burningValue;

            if (BurningEffects.Count == 0)
                Burning = false;
        }
        if (Decaying)
        {
            highestDecaying = 1;
            foreach (var decay in DecayingEffects)
            {
                if (decay.snapshot.decayStrength > highestDecaying)
                    highestDecaying = decay.snapshot.decayStrength;
            }

            decayingValue = rootCharacter.totalStats.Health_Max * (DecayingBaseValue * highestDecaying) * Time.deltaTime;
            decayingValue /= (1 + rootCharacter.totalStats.Decay_Resistance_AddPercent.value);
            totalHealthLoss += decayingValue;

            if (DecayingEffects.Count == 0)
                Decaying = false;
        }
        if (totalDistortion > 0)
        {
            if (totalDistortion > State_Distortion.baseThreshold * rootCharacter.totalStats.Mana_Max)
            {
                totalManaLoss += State_Distortion.percentManaReduction * rootCharacter.totalStats.Mana_Max;
                totalDistortion = 0;
            }

            totalDistortion -= totalDistortion - (State_Distortion.decayRate * rootCharacter.totalStats.Mana_Max * Time.deltaTime);
            if (totalDistortion < 1)
                totalDistortion = 0;
        }
        if (Frostbitten)
        {
            highestFrostbitten = 1;
            foreach (var frostbite in FrostbittenEffects)
            {
                if (frostbite.snapshot.frostbiteStrength > highestFrostbitten)
                    highestFrostbitten = frostbite.snapshot.frostbiteStrength;
            }

            frostbittenValue = rootCharacter.totalStats.Health_Max * (FrostbittenBaseValue * highestFrostbitten) * Time.deltaTime;
            frostbittenValue /= (1 + rootCharacter.totalStats.Frostbite_Resistance_AddPercent.value);
            totalHealthLoss += frostbittenValue;

            if (FrostbittenEffects.Count == 0)
                Frostbitten = false;
        }
        if (totalOvercharged > 0)
        {
            if (totalOvercharged > State_Overcharge.baseThreshold)
                Overcharged = true;
            else
                Overcharged = false;

            totalOvercharged -= totalOvercharged * State_Overcharge.decayRate * Time.deltaTime;
            if (totalOvercharged < 1)
                totalOvercharged = 0;
        }
        if (SoulRotting)
        {
            totalSoulRotting = 0;
            for (int i = SoulRottingEffects.Count - 1; i > -1; i--)
            {
                totalSoulRotting += SoulRottingEffects[i].snapshot.soulrotStrength;
                SoulRottingEffects[i].currentDuration -= Time.deltaTime;

                if (SoulRottingEffects[i].currentDuration < 0)
                    SoulRottingEffects.RemoveAt(i);
            }

            soulRottingValue = (totalSoulRotting * State_SoulRot.rotCostPercent / State_SoulRot.baseDuration) * Time.deltaTime;
            totalHealthLoss += soulRottingValue;
            totalManaLoss -= rootCharacter.totalStats.Mana_Max * State_SoulRot.rotManaGain * Time.deltaTime;

            if (SoulRottingEffects.Count == 0)
                SoulRotting = false;
        }
        if (totalRimeGuardProgress > 0)
        {
            if (totalRimeGuardProgress > State_RimeGuard.baseThreshold)
            {
                rimeGuardCharges++;
                totalRimeGuardProgress -= State_RimeGuard.baseThreshold;

                if (rimeGuardCharges > 0)
                    RimeGuard = true;
                else
                    RimeGuard = false;
            }
        }

        if (totalHealthLoss > 0)
            rootCharacter.ResolveHit(totalHealthLoss, true);
        else if (totalHealthLoss < 0)
            rootCharacter.ResolveHeal(totalHealthLoss, true);

        if (totalManaLoss != 0)
            rootCharacter.totalStats.AddMana(-totalManaLoss);
    }
}