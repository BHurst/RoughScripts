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

        healthBarText.text = Mathf.Floor(character.totalStats.Health_Current.value).ToString() + "/" + character.totalStats.Health_Max.value.ToString();
    }
}