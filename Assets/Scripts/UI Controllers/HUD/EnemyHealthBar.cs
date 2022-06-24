using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{
    public bool active = false;
    public float timer = 0;
    public bool recentlyHit = false;

    public void Disappear()
    {
        healthBar.GetComponent<Image>().enabled = false;
        healthBarDamaged.GetComponent<Image>().enabled = false;
        healthBarHealed.GetComponent<Image>().enabled = false;
        active = false;
        recentlyHit = false;
        timer = 0;
    }

    void Show()
    {
        healthBar.GetComponent<Image>().enabled = true;
        healthBarDamaged.GetComponent<Image>().enabled = true;
        healthBarHealed.GetComponent<Image>().enabled = true;
        active = true;
    }

    public void ResetDisplayTimer()
    {
        recentlyHit = true;
        timer = 0;
    }

    public void UpdateEnemyHealthBar()
    {
        if (character.totalStats.Health_Current < character.totalStats.Health_Max && recentlyHit)
        {
            timer += Time.deltaTime;
            
            UpdateHealthBar();
            Show();
            if (timer > 10)
                Disappear();
        }
        else
            Disappear();
    }
}