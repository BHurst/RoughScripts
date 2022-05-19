using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    public Text healthBarText;

    private void Awake()
    {
        character = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
    }

    void Update()
    {
        UpdateHealthBar();

        healthBarText.text = Mathf.Floor(character.totalStats.Health_Current).ToString() + "/" + character.totalStats.Health_Max.ToString();
    }
}