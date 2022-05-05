using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{
    void Update()
    {
        if (character.totalStats.Health_Current.value < character.totalStats.Health_Max.value)
            healthBarDamaged.gameObject.SetActive(true);
        else
            healthBarDamaged.gameObject.SetActive(false);

        UpdateHealthBar();
        healthBarDamaged.transform.rotation = Quaternion.LookRotation(healthBarDamaged.transform.position - GameWorldReferenceClass.GW_PlayerCamera.transform.position);
    }
}