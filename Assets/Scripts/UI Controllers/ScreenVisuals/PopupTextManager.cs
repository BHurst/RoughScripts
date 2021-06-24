using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class PopupTextManager : MonoBehaviour
{
    public static List<PopupTextInfo> damageTextInfos = new List<PopupTextInfo>();
    public static List<PopupTextInfo> healingTextInfos = new List<PopupTextInfo>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public static void CreateDamageText(int text, GameWorldReferenceClass.HitType hitType, Vector3 location)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text.ToString();

        if (hitType == GameWorldReferenceClass.HitType.Hit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, .92f, .016f, 1); //Yellow
        }
        else if (hitType == GameWorldReferenceClass.HitType.Crit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, .72f, .016f, 1); //Yellow-Orange
        }

        newDamageText.transform.position = location + new Vector3(0, 1, 0);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
    }

    public static void CreateHealText(int text, GameWorldReferenceClass.HitType hitType, Vector3 location)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text.ToString();

        if (hitType == GameWorldReferenceClass.HitType.Hit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 1f, 1); //Blue
        }
        else if (hitType == GameWorldReferenceClass.HitType.Crit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(.1f, .1f, 1f, 1); //Light Blue
        }

        newDamageText.transform.position = location + new Vector3(0, 1, 0);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Heal);
    }

    public static void CreatePopupText(string text, Transform unit)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text;
        newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1); //White
        newDamageText.transform.position = unit.position + new Vector3(0, 1, 0);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
    }

    public static void AddHit(Guid unit, float value, Vector3 location)
    {
        var found = damageTextInfos.FirstOrDefault(x => x.damagedUnit == unit);

        if (found != null)
        {
            found.textObject.text = (float.Parse(found.textObject.text) + value).ToString();
            found.textObject.GetComponent<FloatingDamage>().ResetOnDamage();
        }
        else
        {
            GameObject newDamageText = ResourceManager.RestoreDamageText();
            newDamageText.GetComponent<TextMeshProUGUI>().text = value.ToString();
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, 0, 0, 1); //White
            newDamageText.transform.position = location + new Vector3(0, 1, 0);
            newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
            newDamageText.GetComponent<FloatingDamage>().unitTotrack = GameWorldReferenceClass.GetUnitByID(unit).transform;
            damageTextInfos.Add(new PopupTextInfo() {damagedUnit = unit, damageLocation = location, textObject = newDamageText.GetComponent<TextMeshProUGUI>() });
        }
    }

    public static void AddHeal(Guid unit, float value, Vector3 location)
    {
        var found = healingTextInfos.FirstOrDefault(x => x.damagedUnit == unit);

        if (found != null)
        {
            found.textObject.text = (float.Parse(found.textObject.text) + value).ToString();
            found.textObject.GetComponent<FloatingDamage>().ResetOnDamage();
        }
        else
        {
            GameObject newDamageText = ResourceManager.RestoreDamageText();
            newDamageText.GetComponent<TextMeshProUGUI>().text = value.ToString();
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(0, 1f, 0, 1); //White
            newDamageText.transform.position = location + new Vector3(0, 1, 0);
            newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Heal);
            newDamageText.GetComponent<FloatingDamage>().unitTotrack = GameWorldReferenceClass.GetUnitByID(unit).transform;
            healingTextInfos.Add(new PopupTextInfo() { damagedUnit = unit, damageLocation = location, textObject = newDamageText.GetComponent<TextMeshProUGUI>() });
        }
    }
}