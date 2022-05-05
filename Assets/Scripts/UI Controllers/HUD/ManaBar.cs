using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public RootUnit character;
    public Image manaBar;
    public Text manaText;

    private void Awake()
    {
        character = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
    }

    public void Update()
    {
        manaBar.fillAmount = character.totalStats.Mana_Current.value / character.totalStats.Mana_Max.value;
        manaText.text = Mathf.Floor(character.totalStats.Mana_Current.value).ToString() + "/" + character.totalStats.Mana_Max.value.ToString();
    }
}