using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStates
{
    public List<Status_Distortion> DistortionEffects = new List<Status_Distortion>();
    public bool Distorted = false;
    public float DistortionMinValue = 1;
    float highestDistortion = 1;
    float distortionValue = 0;
    public List<Status_SoulRot> SoulRottingEffects = new List<Status_SoulRot>();
    public bool SoulRotting = false;
    public float SoulRottingMinValue = .01f;
    float totalSoulRotting = 1;
    float soulRottingValue = 0;
    public List<Status_Burn> BurningEffects = new List<Status_Burn>();
    public bool Burning = false;
    public float BurningMinValue = 0;
    float highestBurning = 1;
    float burningValue = 0;
    public List<Status_Frostbite> FrostbittenEffects = new List<Status_Frostbite>();
    public bool Frostbitten = false;
    public float FrostbittenMinValue = 0;
    float highestFrostbitten = 1;
    float frostbittenValue = 0;
    public List<Status_Decay> DecayingEffects = new List<Status_Decay>();
    public bool Decaying = false;
    public float DecayingMinValue = .0025f;
    float highestDecaying = 1;
    float decayingValue = 0;
    public List<Status_Bleed> BleedingEffects = new List<Status_Bleed>();
    public bool Bleeding = false;
    public float BleedingMinValue = 0;
    float highestBleeding = 1;
    float bleedingValue = 0;

    float totalHealthLoss = 0;
    float totalManaLoss = 0;

    public void ClearState()
    {
        Distorted = false;
        SoulRotting = false;
        Burning = false;
        Frostbitten = false;
        Decaying = false;
        Bleeding = false;
    }

    public void AddSpecialStatus(SpecialStatus specialStatus)
    {
        if (specialStatus is Status_Distortion)
        {
            DistortionEffects.Add((Status_Distortion)specialStatus);
            Distorted = true;
        }
        else if (specialStatus is Status_SoulRot)
        {
            SoulRottingEffects.Add((Status_SoulRot)specialStatus);
            SoulRotting = true;
        }
        else if (specialStatus is Status_Burn)
        {
            BurningEffects.Add((Status_Burn)specialStatus);
            Burning = true;
        }
        else if (specialStatus is Status_Frostbite)
        {
            FrostbittenEffects.Add((Status_Frostbite)specialStatus);
            Frostbitten = true;
        }
        else if (specialStatus is Status_Decay)
        {
            DecayingEffects.Add((Status_Decay)specialStatus);
            Decaying = true;
        }
        else if (specialStatus is Status_Distortion)
        {
            BleedingEffects.Add((Status_Bleed)specialStatus);
            Bleeding = true;
        }
    }

    public void StateTick(RootCharacter rootCharacter)
    {
        totalHealthLoss = 0;
        totalManaLoss = 0;

        if (Distorted)
        {
            highestDistortion = 1;
            foreach (var distort in DistortionEffects)
            {
                if (distort.snapshot.strength > highestDistortion)
                    highestDistortion = distort.snapshot.strength;
            }

            distortionValue = rootCharacter.totalStats.Health_Max * (DistortionMinValue * highestDistortion) * Time.deltaTime;
            distortionValue = (distortionValue / (1 + rootCharacter.totalStats.Distortion_Resistance_AddPercent.value));
            totalHealthLoss += distortionValue;

            if (DistortionEffects.Count == 0)
                Distorted = false;
        }
        if (SoulRotting)
        {
            totalSoulRotting = 0;
            for (int i = SoulRottingEffects.Count - 1; i > -1; i--)
            {
                totalSoulRotting += SoulRottingEffects[i].snapshot.strength;
                SoulRottingEffects[i].currentDuration -= Time.deltaTime;

                if (SoulRottingEffects[i].currentDuration < 0)
                    SoulRottingEffects.RemoveAt(i);
            }

            soulRottingValue = (totalSoulRotting * Status_SoulRot.rotCostPercent / Status_SoulRot.baseDuration) * Time.deltaTime;
            totalHealthLoss += soulRottingValue;
            totalManaLoss -= rootCharacter.totalStats.Mana_Max * SoulRottingMinValue * Time.deltaTime;

            if (SoulRottingEffects.Count == 0)
                SoulRotting = false;
        }
        if (Burning)
        {
            highestBurning = 1;
            foreach (var burn in BurningEffects)
            {
                if (burn.snapshot.strength > highestBurning)
                    highestBurning = burn.snapshot.strength;
            }

            burningValue = rootCharacter.totalStats.Health_Max * (BurningMinValue * highestBurning) * Time.deltaTime;
            burningValue = (burningValue / (1 + rootCharacter.totalStats.Burn_Resistance_AddPercent.value));
            totalHealthLoss += burningValue;

            if (BurningEffects.Count == 0)
                Burning = false;
        }
        if (Frostbitten)
        {
            highestFrostbitten = 1;
            foreach (var frostbite in FrostbittenEffects)
            {
                if (frostbite.snapshot.strength > highestFrostbitten)
                    highestFrostbitten = frostbite.snapshot.strength;
            }

            frostbittenValue = rootCharacter.totalStats.Health_Max * (FrostbittenMinValue * highestFrostbitten) * Time.deltaTime;
            frostbittenValue = (frostbittenValue / (1 + rootCharacter.totalStats.Frostbite_Resistance_AddPercent.value));
            totalHealthLoss += frostbittenValue;

            if (FrostbittenEffects.Count == 0)
                Frostbitten = false;
        }
        if (Decaying)
        {
            highestDecaying = 1;
            foreach(var decay in DecayingEffects)
            {
                if (decay.snapshot.strength > highestDecaying)
                    highestDecaying = decay.snapshot.strength;
            }

            decayingValue = rootCharacter.totalStats.Health_Max * (DecayingMinValue * highestDecaying) * Time.deltaTime;
            decayingValue = (decayingValue / (1 + rootCharacter.totalStats.Decay_Resistance_AddPercent.value));
            totalHealthLoss += decayingValue;

            if (DecayingEffects.Count == 0)
                Decaying = false;
        }
        if (Bleeding)
        {
            highestBleeding = 1;
            foreach (var bleed in BleedingEffects)
            {
                if (bleed.snapshot.strength > highestBleeding)
                    highestBleeding = bleed.snapshot.strength;
            }

            bleedingValue = rootCharacter.totalStats.Health_Max * (BleedingMinValue * highestBleeding) * Time.deltaTime;
            bleedingValue = (bleedingValue / (1 + rootCharacter.totalStats.Bleed_Resistance_AddPercent.value));
            totalHealthLoss += bleedingValue;

            if (BleedingEffects.Count == 0)
                Bleeding = false;
        }

        if (totalHealthLoss > 0)
            rootCharacter.ResolveHit(totalHealthLoss, true);
        else if (totalHealthLoss < 0)
            rootCharacter.ResolveHeal(totalHealthLoss, true);

        if (totalManaLoss != 0)
            rootCharacter.totalStats.AddMana(-totalManaLoss);
    }
}