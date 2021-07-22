using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    public Text healthBarText;

    void Update()
    {
        UpdateHealthBar();

        healthBarText.text = Mathf.Round(character.unitHealth).ToString() + "/" + character.unitMaxHealth.ToString();
    }
}