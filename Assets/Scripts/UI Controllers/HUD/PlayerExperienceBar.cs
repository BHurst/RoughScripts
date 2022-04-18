using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceBar : MonoBehaviour
{
    public Image barFill;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI currentLevel;

    public void UpdateExperienceUI(CharacterLevel characterLevel)
    {
        currentLevel.text = "Lv. " + characterLevel.currentLevel;

        experienceText.text = (int)characterLevel.currentExperience + "/" + characterLevel.nextLevelExperience;

        barFill.fillAmount = characterLevel.currentExperience / characterLevel.nextLevelExperience;
    }
}