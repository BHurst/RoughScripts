using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel
{

    public Transform character;
    public int currentLevel = 1;
    public float currentExperience = 0;
    public int nextLevelExperience = 2000;
    public int availableTalentPoints = 0;
    public int maxTalentPoints = 0;

    public void CalculateExperience()
    {
        nextLevelExperience = nextLevelExperience + ((currentLevel - 1) * (10 + currentLevel * 15));
    }

    public void CalculateRewardExperience(int defeatedEnemyLevel, int rewardXp)
    {
        GainExperience(rewardXp);
    }

    public void GainExperience(int xp)
    {
        currentExperience += xp;
        while (currentExperience >= nextLevelExperience)
        {
            currentExperience -= nextLevelExperience;
            currentLevel++;
            availableTalentPoints += 3;
            maxTalentPoints += 3;
            CalculateExperience();
        }

        GameObject.Find("UIController").GetComponent<PlayerExperienceBar>().UpdateExperienceUI(this);
    }
}