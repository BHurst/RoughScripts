using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel {

    public Transform character;
    public int currentLevel = 1;
    public int currentExperience = 0;
    public int nextLevelExperience = 2000;
    public int rewardExperience = 200;
    public int availableTalentPoints = 0;

    public void CalculateExperience()
    {
        double tempNumberOfEnemies = 10;
        double tempNextLevelXp = 2000;
        for (int i = 1; i < currentLevel; i++)
        {
            tempNumberOfEnemies = Math.Pow(tempNumberOfEnemies, 1.01) + 1;
            tempNextLevelXp = Math.Pow(tempNextLevelXp, 1.01) + 100;
        }
        rewardExperience = (int)(tempNextLevelXp / tempNumberOfEnemies);
        nextLevelExperience = (int)tempNextLevelXp;
    }

    public int CalculateRewardExperience(int defeatedEnemyLevel)
    {
        int rewardXp = 40;
        int averageLevel = (defeatedEnemyLevel + currentLevel) / 2;

        for (int i = 1; i < averageLevel ; i++)
        {
            nextLevelExperience = (int)(nextLevelExperience * 1.1f);
        }

        return rewardXp;
    }

    public void GainExperience(int xp)
    {
        currentExperience += xp;
        if(currentExperience >= nextLevelExperience)
        {
            currentExperience -= nextLevelExperience;
            currentLevel++;
            availableTalentPoints += 3;
            CalculateExperience();

            //CharacterPanelScripts.CreatePopupText("Level Up", character.position);

            if (currentExperience >= nextLevelExperience)
                GainExperience(0);
        }
    }
}