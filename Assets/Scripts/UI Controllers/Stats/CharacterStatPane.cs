using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStatPane : MonoBehaviour
{
    public GameObject mainPanel;
    public RootCharacter unit;
    public GameObject GeneralStatPane;
    public Button GeneralStatTab;
    public GameObject GeneralStatContent;
    public GameObject DamageStatPane;
    public Button DamageStatTab;
    public GameObject DamageStatContent;
    public GameObject FormStatPane;
    public Button FormStatTab;
    public GameObject FormStatContent;
    public GameObject ReserveStatPane;
    public Button ReserveStatTab;
    public GameObject ReserveStatContent;
    public GameObject MiscStatPane;
    public Button MiscStatTab;
    public GameObject MiscStatContent;

    private void Start()
    {
        mainPanel.transform.position = transform.position;
        if (unit == null)
            unit = GameObject.Find("PlayerData").GetComponent<RootCharacter>();
        mainPanel.SetActive(false);
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        ShowGeneral();
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
    }

    public void ShowGeneral()
    {
        GeneralStatPane.SetActive(true);
        DamageStatPane.SetActive(false);
        FormStatPane.SetActive(false);
        ReserveStatPane.SetActive(false);
        MiscStatPane.SetActive(false);

        foreach (Transform kid in GeneralStatContent.transform)
            Destroy(kid.gameObject);

        GameObject healthSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        healthSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Life";
        healthSlot.transform.SetParent(GeneralStatContent.transform);
        healthSlot.transform.Find("Value").GetComponent<Text>().text = unit.totalStats.Health_Max.ToString();

        GameObject healthRegenSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        healthRegenSlot.transform.Find("Stat").GetComponent<Text>().text = "Life Regeneration";
        healthRegenSlot.transform.SetParent(GeneralStatContent.transform);
        healthRegenSlot.transform.Find("Value").GetComponent<Text>().text = (Mathf.Round(unit.totalStats.Health_Regeneration * 100f) / 100f).ToString() + "/sec";

        GameObject manaSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        manaSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Mana";
        manaSlot.transform.SetParent(GeneralStatContent.transform);
        manaSlot.transform.Find("Value").GetComponent<Text>().text = unit.totalStats.Mana_Max.ToString();

        GameObject manaRegenSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        manaRegenSlot.transform.Find("Stat").GetComponent<Text>().text = "Mana Regeneration";
        manaRegenSlot.transform.SetParent(GeneralStatContent.transform);
        manaRegenSlot.transform.Find("Value").GetComponent<Text>().text = (Mathf.Round(unit.totalStats.Mana_Regeneration * 100f) / 100f).ToString() + "/sec";

        GameObject speedSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        speedSlot.transform.Find("Stat").GetComponent<Text>().text = "Movement Speed";
        speedSlot.transform.SetParent(GeneralStatContent.transform);
        speedSlot.transform.Find("Value").GetComponent<Text>().text = unit.totalStats.MovementSpeed.ToString();

        foreach (FieldInfo field in typeof(UnitStats).GetFields())
        {
            string cleanedName = field.Name.Replace("_", " ");
            UnitStat stat;
            if (field.GetValue(unit.totalStats) is UnitStat)
            {
                stat = (UnitStat)field.GetValue(unit.totalStats);

                if (stat.displayOnStatScreen && (cleanedName.Contains("Health") || cleanedName.Contains("Mana") || cleanedName.Contains("Movement") || cleanedName.Contains("Cast")))
                {
                    if (cleanedName.Contains("Flat") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(GeneralStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + stat.value.ToString();
                    }
                    else if (cleanedName.Contains("Resistance") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(GeneralStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = ((int)(((1 / -(1 + stat.value)) + 1) * 10000) / 100f).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("AddPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(GeneralStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round(stat.value * 100).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("MultiplyPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(GeneralStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round((stat.value - 1) * 100).ToString() + "%";
                    }
                    else if (stat.value != stat.defaultValue && stat.displayOnStatScreen)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(GeneralStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = stat.value.ToString();
                    }
                }
            }
        }
    }
    public void ShowDamage()
    {
        GeneralStatPane.SetActive(false);
        DamageStatPane.SetActive(true);
        FormStatPane.SetActive(false);
        ReserveStatPane.SetActive(false);
        MiscStatPane.SetActive(false);

        foreach (Transform kid in DamageStatContent.transform)
            Destroy(kid.gameObject);

        foreach (FieldInfo field in typeof(UnitStats).GetFields())
        {
            string cleanedName = field.Name.Replace("_", " ");
            UnitStat stat;
            if (field.GetValue(unit.totalStats) is UnitStat)
            {
                stat = (UnitStat)field.GetValue(unit.totalStats);

                if (stat.displayOnStatScreen && cleanedName.Contains("Damage"))
                {
                    if (cleanedName.Contains("Flat") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(DamageStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + stat.value.ToString();
                    }
                    else if (cleanedName.Contains("Resistance") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(DamageStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = ((int)(((1 / -(1 + stat.value)) + 1) * 10000) / 100f).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("AddPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(DamageStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round(stat.value * 100).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("MultiplyPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(DamageStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round((stat.value - 1) * 100).ToString() + "%";
                    }
                    else if (stat.value != stat.defaultValue && stat.displayOnStatScreen)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(DamageStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = stat.value.ToString();
                    }
                }
            }
        }
    }

    public void ShowForms()
    {
        GeneralStatPane.SetActive(false);
        DamageStatPane.SetActive(false);
        FormStatPane.SetActive(true);
        ReserveStatPane.SetActive(false);
        MiscStatPane.SetActive(false);

        foreach (Transform kid in FormStatContent.transform)
            Destroy(kid.gameObject);
    }

    public void ShowReserve()
    {
        GeneralStatPane.SetActive(false);
        DamageStatPane.SetActive(false);
        FormStatPane.SetActive(false);
        ReserveStatPane.SetActive(true);
        MiscStatPane.SetActive(false);

        foreach (Transform kid in ReserveStatContent.transform)
            Destroy(kid.gameObject);

        GameObject airSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        airSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Air Reserve";
        airSlot.transform.SetParent(ReserveStatContent.transform);
        airSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.AirReserve_Max + unit.totalStats.AirReserve_Max_Flat.value).ToString();

        GameObject arcaneSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        arcaneSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Arcane Reserve";
        arcaneSlot.transform.SetParent(ReserveStatContent.transform);
        arcaneSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.ArcaneReserve_Max + unit.totalStats.ArcaneReserve_Max_Flat.value).ToString();

        GameObject astralSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        astralSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Astral Reserve";
        astralSlot.transform.SetParent(ReserveStatContent.transform);
        astralSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.AstralReserve_Max + unit.totalStats.AstralReserve_Max_Flat.value).ToString();

        GameObject earthSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        earthSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Earth Reserve";
        earthSlot.transform.SetParent(ReserveStatContent.transform);
        earthSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.EarthReserve_Max + unit.totalStats.EarthReserve_Max_Flat.value).ToString();

        GameObject electricitySlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        electricitySlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Electricity Reserve";
        electricitySlot.transform.SetParent(ReserveStatContent.transform);
        electricitySlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.ElectricityReserve_Max + unit.totalStats.ElectricityReserve_Max_Flat.value).ToString();

        GameObject etherealSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        etherealSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Ethereal Reserve";
        etherealSlot.transform.SetParent(ReserveStatContent.transform);
        etherealSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.EtherealReserve_Max + unit.totalStats.EtherealReserve_Max_Flat.value).ToString();

        GameObject fireSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        fireSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Fire Reserve";
        fireSlot.transform.SetParent(ReserveStatContent.transform);
        fireSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.FireReserve_Max + unit.totalStats.FireReserve_Max_Flat.value).ToString();

        GameObject iceSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        iceSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Ice Reserve";
        iceSlot.transform.SetParent(ReserveStatContent.transform);
        iceSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.IceReserve_Max + unit.totalStats.IceReserve_Max_Flat.value).ToString();

        GameObject kineticSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        kineticSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Kinetic Reserve";
        kineticSlot.transform.SetParent(ReserveStatContent.transform);
        kineticSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.KineticReserve_Max + unit.totalStats.KineticReserve_Max_Flat.value).ToString();

        GameObject lifeSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        lifeSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Life Reserve";
        lifeSlot.transform.SetParent(ReserveStatContent.transform);
        lifeSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.LifeReserve_Max + unit.totalStats.LifeReserve_Max_Flat.value).ToString();

        GameObject waterSlot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
        waterSlot.transform.Find("Stat").GetComponent<Text>().text = "Maximum Water Reserve";
        waterSlot.transform.SetParent(ReserveStatContent.transform);
        waterSlot.transform.Find("Value").GetComponent<Text>().text = (unit.totalStats.WaterReserve_Max + unit.totalStats.WaterReserve_Max_Flat.value).ToString();
    }

    public void ShowMisc()
    {
        GeneralStatPane.SetActive(false);
        DamageStatPane.SetActive(false);
        FormStatPane.SetActive(false);
        ReserveStatPane.SetActive(false);
        MiscStatPane.SetActive(true);

        foreach (Transform kid in MiscStatContent.transform)
            Destroy(kid.gameObject);

        foreach (FieldInfo field in typeof(UnitStats).GetFields())
        {
            string cleanedName = field.Name.Replace("_", " ");
            UnitStat stat;
            if (field.GetValue(unit.totalStats) is UnitStat)
            {
                stat = (UnitStat)field.GetValue(unit.totalStats);

                if (stat.displayOnStatScreen && (cleanedName.Contains("Ability") || cleanedName.Contains("Projectile")))
                {
                    if (cleanedName.Contains("Flat") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(MiscStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + stat.value.ToString();
                    }
                    else if (cleanedName.Contains("Resistance") && stat.value != stat.defaultValue)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(MiscStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = ((int)(((1 / -(1 + stat.value)) + 1) * 10000) / 100f).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("AddPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(MiscStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round(stat.value * 100).ToString() + "%";
                    }
                    else if ((cleanedName.Contains("MultiplyPercent") && stat.value != stat.defaultValue))
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(MiscStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = (stat.value < 0 ? "-" : "+") + Mathf.Round((stat.value - 1) * 100).ToString() + "%";
                    }
                    else if (stat.value != stat.defaultValue && stat.displayOnStatScreen)
                    {
                        GameObject slot = Instantiate(Resources.Load("Prefabs/UIComponents/StatSlot")) as GameObject;
                        slot.transform.Find("Stat").GetComponent<Text>().text = stat.readableName;
                        slot.transform.SetParent(MiscStatContent.transform);
                        slot.transform.Find("Value").GetComponent<Text>().text = stat.value.ToString();
                    }
                }
            }
        }
    }
}