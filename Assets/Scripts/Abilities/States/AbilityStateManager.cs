using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStateManager
{
    public CalculatedStateStats snapshot = new CalculatedStateStats();
    public bool applyBleed = false;
    public bool applyBurn = false;
    public bool applyDecay = false;
    public bool applyDistortion = false;
    public bool applyFrostbite = false;
    public bool applyOvercharge = false;
    public bool applySoulRot = false;
    public bool applyRimeGuard = false;

    public void PickState(RootAbility ability, RootCharacter owner)
    {
        if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Kinetic)
            applyBleed = true;
        else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Fire)
            applyBurn = true;
        else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Life)
            applyDecay = true;
        //else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Arcane)
        //    applyDistortion = true;
        else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Ice)
            applyRimeGuard = true;
        else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Ethereal)
            applySoulRot = true;
        else if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Electricity)
            applyOvercharge = true;
    }

    public void ApplyStateOnHit(RootCharacter target)
    {
        ApplyBleed(target);
        ApplyBurn(target);
        ApplyDecay(target);
        ApplyDistortion(target);
        ApplyFrostbite(target);
    }

    public void ApplyStateOnHit(RootCharacter target, RootCharacter owner)
    {
        ApplyBleed(target, owner);
        ApplyBurn(target, owner);
        ApplyDecay(target, owner);
        ApplyDistortion(target, owner);
        ApplyFrostbite(target, owner);
    }

    public void ApplyStateOnCast(RootCharacter owner)
    {
        ApplyRimeGuard(owner, owner);
        ApplyOvercharge(owner, owner);
        ApplySoulRot(owner, owner);
    }

    public void ApplyBleed(RootCharacter target)
    {
        if (applyBleed)
        {
            State_Bleed newSR = new State_Bleed();
            newSR.snapshot = snapshot;

            target.AddState(newSR);
        }
    }

    public void ApplyBleed(RootCharacter target, RootCharacter owner)
    {
        if (applyBleed)
        {
            State_Bleed newSR = new State_Bleed();
            newSR.snapshot = snapshot;

            target.AddState(newSR);
        }
    }

    public void ApplyBurn(RootCharacter target)
    {
        if (applyBurn)
        {
            State_Burn newO = new State_Burn();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyBurn(RootCharacter target, RootCharacter owner)
    {
        if (applyBurn)
        {
            State_Burn newO = new State_Burn();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyDecay(RootCharacter target)
    {
        if (applyDecay)
        {
            State_Decay newO = new State_Decay();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyDecay(RootCharacter target, RootCharacter owner)
    {
        if (applyDecay)
        {
            State_Decay newO = new State_Decay();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyDistortion(RootCharacter target)
    {
        if (applyDistortion)
        {
            State_Distortion newO = new State_Distortion();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyDistortion(RootCharacter target, RootCharacter owner)
    {
        if (applyDistortion)
        {
            State_Distortion newO = new State_Distortion();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyFrostbite(RootCharacter target)
    {
        if (applyFrostbite)
        {
            State_Frostbite newO = new State_Frostbite();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyFrostbite(RootCharacter target, RootCharacter owner)
    {
        if (applyFrostbite)
        {
            State_Frostbite newO = new State_Frostbite();
            newO.snapshot = snapshot;

            target.AddState(newO);
        }
    }

    public void ApplyOvercharge(RootCharacter target, RootCharacter owner)
    {
        if (applyOvercharge)
        {
            State_Overcharge newO = new State_Overcharge();
            newO.snapshot = snapshot;

            owner.AddState(newO);
        }
    }

    public void ApplyRimeGuard(RootCharacter target, RootCharacter owner)
    {
        if (applyRimeGuard)
        {
            State_RimeGuard newSR = new State_RimeGuard();
            newSR.snapshot = snapshot;

            owner.AddState(newSR);
        }
    }

    public void ApplySoulRot(RootCharacter target, RootCharacter owner)
    {
        if (applySoulRot)
        {
            State_SoulRot newSR = new State_SoulRot();
            newSR.snapshot = snapshot;

            owner.AddState(newSR);
        }
    }
}