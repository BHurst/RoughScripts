using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{
    void Update()
    {
        if (character.unitHealth < character.unitMaxHealth)
            healthBarDamaged.gameObject.SetActive(true);
        else
            healthBarDamaged.gameObject.SetActive(false);

        UpdateHealthBar();
        healthBarDamaged.transform.rotation = Quaternion.LookRotation(healthBarDamaged.transform.position - GameWorldReferenceClass.GW_PlayerCamera.transform.position);
    }
}