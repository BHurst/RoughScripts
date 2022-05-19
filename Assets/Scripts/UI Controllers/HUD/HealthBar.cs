using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    public RootCharacter character;
    public Image healthBar;
    public Image healthBarDamaged;
    public Image healthBarHealed;

    public void UpdateHealthBar()
    {
        if (healthBarDamaged.fillAmount >= character.totalStats.Health_Current / character.totalStats.Health_Max)
        {
            healthBar.fillAmount = character.totalStats.Health_Current / character.totalStats.Health_Max;
            healthBarHealed.fillAmount = character.totalStats.Health_Current / character.totalStats.Health_Max;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.totalStats.Health_Current / character.totalStats.Health_Max, .1f);
        }
        else if (healthBar.fillAmount <= character.totalStats.Health_Current / character.totalStats.Health_Max)
        {
            healthBarHealed.fillAmount = character.totalStats.Health_Current / character.totalStats.Health_Max;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.totalStats.Health_Current / character.totalStats.Health_Max, .1f);
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, character.totalStats.Health_Current / character.totalStats.Health_Max, .1f);
        }
    }
}