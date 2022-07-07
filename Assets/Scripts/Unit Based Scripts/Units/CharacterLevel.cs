using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterLevel
{
    public int currentLevel = 1;
    public float currentExperience = 0;
    public int nextLevelExperience = 2000;
    public int availableTalentPoints = 0;
    public int maxTalentPoints = 0;
    [field : NonSerialized]
    public event EventHandler<CharacterLevel> LevelMilestone;

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
            LevelUp();
        }

        GameObject.Find("UIController").GetComponent<PlayerExperienceBar>().UpdateExperienceUI(this);
    }

    public void LevelUp()
    {
        currentExperience -= nextLevelExperience;
        currentLevel++;
        availableTalentPoints += 3;
        maxTalentPoints += 3;
        CalculateExperience();
        LevelMilestone?.Invoke(this, this);
    }
}