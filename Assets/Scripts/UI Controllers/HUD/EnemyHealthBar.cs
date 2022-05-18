using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{
    public bool active = false;

    public void Disappear()
    {
        healthBar.GetComponent<Image>().enabled = false;
        healthBarDamaged.GetComponent<Image>().enabled = false;
        healthBarHealed.GetComponent<Image>().enabled = false;
        active = false;
    }

    void Show()
    {
        healthBar.GetComponent<Image>().enabled = true;
        healthBarDamaged.GetComponent<Image>().enabled = true;
        healthBarHealed.GetComponent<Image>().enabled = true;
        active = true;
    }

    public void UpdateEnemyHealthBar()
    {
        if (character.totalStats.Health_Current.value < character.totalStats.Health_Max.value)
        {
            UpdateHealthBar();
            Show();
        }
        else
            Disappear();
    }
}