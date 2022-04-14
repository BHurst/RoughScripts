using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class PopupTextManager : MonoBehaviour
{
    public GameObject damageOb;
    public TextMeshProUGUI damageText;
    public GameObject healingOb;
    public TextMeshProUGUI healingText;
    public RootUnit unit;

    public void CreatePopupText(string text)
    {
        //GameObject newDamageText = ResourceManager.RestoreDamageText();
        //newDamageText.GetComponent<TextMeshProUGUI>().text = text;
        //newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1);
        //newDamageText.transform.position = unit.transform.position + new Vector3(0, 1, 0);
        //newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
    }

    public void AddHit(float value)
    {
        damageOb.SetActive(true);
        damageText.text = (float.Parse(damageText.text) + Mathf.Round(value * 100f) / 100f).ToString();
        damageOb.GetComponent<FloatingDamage>().ResetOnDamage();

        damageText.color = new Color(1, 0, 0, 1);
        damageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
    }

    public void AddHeal(float value)
    {
        healingOb.SetActive(true);
        healingText.text = (float.Parse(healingText.text) + Mathf.Round(value * 100) / 100).ToString();
        healingOb.GetComponent<FloatingDamage>().ResetOnDamage();

        healingText.color = new Color(0, 1, 0, 1);
        healingText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Heal);
    }

    private void Update()
    {
        transform.SetPositionAndRotation(unit.transform.position + new Vector3(0, 2, 0), GameWorldReferenceClass.GW_PlayerCamera.transform.rotation);
        //transform.LookAt(unit.transform);
    }
}