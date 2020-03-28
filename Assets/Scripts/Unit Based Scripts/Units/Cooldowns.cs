using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldowns
{
    public List<Cooldown> cooldowns = new List<Cooldown>();

    public void AddCooldown(int abilityId, float maxCD)
    {
        Cooldown newCD = new Cooldown();

        newCD.id = abilityId;
        newCD.maxCd = maxCD;
        newCD.currentCd = maxCD;

        cooldowns.Add(newCD);
    }

    public void AddCooldown(int abilityId, float maxCD, float currentCD)
    {
        Cooldown newCD = new Cooldown();

        newCD.id = abilityId;
        newCD.maxCd = maxCD;
        newCD.currentCd = currentCD;

        cooldowns.Add(newCD);
    }

    public void UpdateCooldowns()
    {
        foreach (Cooldown cd in cooldowns)
        {
            if (cd.currentCd > 0)
                cd.currentCd -= Time.deltaTime;
        }

        for (int i = cooldowns.Count - 1; i >= 0; i--)
        {
            if (cooldowns[i].currentCd <= 0)
                cooldowns.RemoveAt(i);
        }
    }
}

public class Cooldown
{
    public int id = 0;
    public float currentCd = 0;
    public float maxCd = 1;
}