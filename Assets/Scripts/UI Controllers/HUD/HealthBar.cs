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
        if (healthBarDamaged.fillAmount >= character.unitHealth / character.unitMaxHealth)
        {
            healthBar.fillAmount = character.unitHealth / character.unitMaxHealth;
            healthBarHealed.fillAmount = character.unitHealth / character.unitMaxHealth;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.unitHealth / character.unitMaxHealth, .1f);
        }
        else if (healthBar.fillAmount <= character.unitHealth / character.unitMaxHealth)
        {
            healthBarHealed.fillAmount = character.unitHealth / character.unitMaxHealth;
            healthBarDamaged.fillAmount = Mathf.Lerp(healthBarDamaged.fillAmount, character.unitHealth / character.unitMaxHealth, .1f);
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, character.unitHealth / character.unitMaxHealth, .1f);
        }
    }
}