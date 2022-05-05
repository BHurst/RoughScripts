using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    public RootUnit character;
    public Image healthBar;
    public Image healthBarDamaged;
    public Image healthBarHealed;

    public void UpdateHealthBar()
    {
        if (healthBarDamaged.fillAmount >= character.totalStats.Health_Current.value / character.totalStats.Health_Max.value)
        {
            healthBar.fillAmount = character.totalStats.Health_Current.value / character.totalStats.Health_Max.value;
            healthBarHealed.fillAmount = character.totalStats.Health_Current.value / character.totalStats.Health_Max.value;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.totalStats.Health_Current.value / character.totalStats.Health_Max.value, .1f);
        }
        else if (healthBar.fillAmount <= character.totalStats.Health_Current.value / character.totalStats.Health_Max.value)
        {
            healthBarHealed.fillAmount = character.totalStats.Health_Current.value / character.totalStats.Health_Max.value;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.totalStats.Health_Current.value / character.totalStats.Health_Max.value, .1f);
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, character.totalStats.Health_Current.value / character.totalStats.Health_Max.value, .1f);
        }
    }
}