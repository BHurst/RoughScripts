using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocusRune : MonoBehaviour
{
    public CharacterTalentsPane characterTalents;
    public LocusRune LocusRune;
    Vector3 positionNorth = new Vector3(0, 500, 0);
    Vector3 positionEast = new Vector3(500, 0, 0);
    Vector3 positionSouth = new Vector3(0, -500, 0);
    Vector3 positionWest = new Vector3(-500, 0, 0);
    public UILocusRuneConnector connectorNorth;
    public UILocusRuneConnector connectorEast;
    public UILocusRuneConnector connectorSouth;
    public UILocusRuneConnector connectorWest;

    UITier1Talent Tier1Talent1;
    UITier1Talent Tier1Talent2;
    UITier1Talent Tier1Talent3;
    UITier1Talent Tier1Talent4;
    UITier1Talent Tier1Talent5;
    UITier1Talent Tier1Talent6;
    UITier1Talent Tier1Talent7;
    UITier1Talent Tier1Talent8;
    List<UITier1Talent> Tier1Talents;
    UITier3Talent Tier3Talent1;
    UITier3Talent Tier3Talent2;
    List<UITier3Talent> Tier3Talents;

    void Start()
    {
        ForceStart();
        Tier1Talents = new List<UITier1Talent>() { Tier1Talent1, Tier1Talent2, Tier1Talent3, Tier1Talent4, Tier1Talent5, Tier1Talent6, Tier1Talent7, Tier1Talent8 };
        Tier3Talents = new List<UITier3Talent>() { Tier3Talent1, Tier3Talent2 };

        SetRune(NewRune());
    }

    public void ForceStart()
    {
        if (characterTalents == null)
            characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        if (connectorNorth == null)
            connectorNorth = transform.Find("ConnectorNorth").GetComponent<UILocusRuneConnector>();
        if (connectorEast == null)
            connectorEast = transform.Find("ConnectorEast").GetComponent<UILocusRuneConnector>();
        if (connectorSouth == null)
            connectorSouth = transform.Find("ConnectorSouth").GetComponent<UILocusRuneConnector>();
        if (connectorWest == null)
            connectorWest = transform.Find("ConnectorWest").GetComponent<UILocusRuneConnector>();

        if (Tier1Talent1 == null)
            transform.Find("Tier1Talent1").TryGetComponent<UITier1Talent>(out Tier1Talent1);
        if (Tier1Talent2 == null)
            transform.Find("Tier1Talent2").TryGetComponent<UITier1Talent>(out Tier1Talent2);
        if (Tier1Talent3 == null)
            transform.Find("Tier1Talent3").TryGetComponent<UITier1Talent>(out Tier1Talent3);
        if (Tier1Talent4 == null)
            transform.Find("Tier1Talent4").TryGetComponent<UITier1Talent>(out Tier1Talent4);
        if (Tier1Talent5 == null)
            transform.Find("Tier1Talent5").TryGetComponent<UITier1Talent>(out Tier1Talent5);
        if (Tier1Talent6 == null)
            transform.Find("Tier1Talent6").TryGetComponent<UITier1Talent>(out Tier1Talent6);
        if (Tier1Talent7 == null)
            transform.Find("Tier1Talent7").TryGetComponent<UITier1Talent>(out Tier1Talent7);
        if (Tier1Talent8 == null)
            transform.Find("Tier1Talent8").TryGetComponent<UITier1Talent>(out Tier1Talent8);

        if (Tier3Talent1 == null)
            transform.Find("Tier3Talent1").TryGetComponent<UITier3Talent>(out Tier3Talent1);
        if (Tier3Talent2 == null)
            transform.Find("Tier3Talent2").TryGetComponent<UITier3Talent>(out Tier3Talent2);
    }

    public void SetRune(LocusRune nR)
    {
        LocusRune = nR;

        for (int i = 0; i < Tier1Talents.Count; i++)
        {
            if(nR.Tier1Talents.Count > i)
            {
                Tier1Talents[i].Initialize(nR.Tier1Talents[i]);
                Tier1Talents[i].gameObject.SetActive(true);
            }
            else
                Tier1Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier3Talents.Count; i++)
        {
            if (nR.Tier3Talents.Count > i)
            {
                Tier3Talents[i].Initialize(nR.Tier3Talents[i]);
                Tier3Talents[i].gameObject.SetActive(true);
            }
            else
                Tier3Talents[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < LocusRune.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad), 100 * Mathf.Sin((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad));
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talent1.transform.position = transform.position + new Vector3(0,-150);
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talent1.transform.position = transform.position + new Vector3(-150, -150);
            Tier3Talent2.transform.position = transform.position + new Vector3(150, -150);
        }
    }

    public void ConnectNorth()
    {
        if (connectorNorth.attachedlocusRune == null)
        {
            GameObject newRune = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune")) as GameObject;
            connectorNorth.attachedlocusRune = newRune.GetComponent<UILocusRune>();
            
            newRune.GetComponent<UILocusRune>().connectorSouth.attachedlocusRune = gameObject.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().LocusRune = NewRune();
            newRune.transform.SetParent(characterTalents.talentContent.transform);
            newRune.transform.position = GetComponent<RectTransform>().position + positionNorth;
        }
    }

    public void ConnectEast()
    {
        if (connectorEast.attachedlocusRune == null)
        {
            GameObject newRune = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune")) as GameObject;
            connectorEast.attachedlocusRune = newRune.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().ForceStart();
            newRune.GetComponent<UILocusRune>().connectorWest.attachedlocusRune = gameObject.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().LocusRune = NewRune();
            newRune.transform.SetParent(characterTalents.talentContent.transform);
            newRune.transform.position = GetComponent<RectTransform>().position + positionEast;
        }
    }

    public void ConnectSouth()
    {
        if (connectorSouth.attachedlocusRune == null)
        {
            GameObject newRune = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune")) as GameObject;
            connectorSouth.attachedlocusRune = newRune.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().ForceStart();
            newRune.GetComponent<UILocusRune>().connectorNorth.attachedlocusRune = gameObject.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().LocusRune = NewRune();
            newRune.transform.SetParent(characterTalents.talentContent.transform);
            newRune.transform.position = GetComponent<RectTransform>().position + positionSouth;
        }
    }

    public void ConnectWest()
    {
        if (connectorWest.attachedlocusRune == null)
        {
            GameObject newRune = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune")) as GameObject;
            connectorWest.attachedlocusRune = newRune.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().ForceStart();
            newRune.GetComponent<UILocusRune>().connectorEast.attachedlocusRune = gameObject.GetComponent<UILocusRune>();
            newRune.GetComponent<UILocusRune>().LocusRune = NewRune();
            newRune.transform.SetParent(characterTalents.talentContent.transform);
            newRune.transform.position = GetComponent<RectTransform>().position + positionWest;
        }
    }

    public LocusRune NewRune()
    {
        return new LocusRune()
        {
            Tier1Talents = new List<Tier1Talent>() {
                new Tier1Talent() { talentName = "talent1", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent2", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Arcane, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent3", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent4", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Earth, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent5", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Electricity, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent6", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Ethereal, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent7", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new Tier1Talent() { talentName = "talent8", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } }

            },
            Tier3Talents = new List<Tier3Talent>()
            {
                new T3_ExplosiveFireOrb(),
                new T3_HotColdSwap()
            }
        };
    }
}