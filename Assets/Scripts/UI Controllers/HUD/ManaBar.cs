using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public RootUnit character;
    public Image manaBar;
    public Text manaText;

    public void Update()
    {
        manaBar.fillAmount = character.unitMana / character.unitMaxMana;
        manaText.text = character.unitMana + "/" + character.unitMaxMana;
    }
}