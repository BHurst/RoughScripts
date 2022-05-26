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

    UISimpleTalent simpleTalent1;
    UISimpleTalent simpleTalent2;
    UISimpleTalent simpleTalent3;
    UISimpleTalent simpleTalent4;
    UISimpleTalent simpleTalent5;
    UISimpleTalent simpleTalent6;
    UISimpleTalent simpleTalent7;
    UISimpleTalent simpleTalent8;
    List<UISimpleTalent> simpleTalents;
    UIComplexTalent complexTalent1;
    UIComplexTalent complexTalent2;
    List<UIComplexTalent> complexTalents;

    void Start()
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

        if (simpleTalent1 == null)
            transform.Find("SimpleTalent1").TryGetComponent<UISimpleTalent>(out simpleTalent1);
        if (simpleTalent2 == null)
            transform.Find("SimpleTalent2").TryGetComponent<UISimpleTalent>(out simpleTalent2);
        if (simpleTalent3 == null)
            transform.Find("SimpleTalent3").TryGetComponent<UISimpleTalent>(out simpleTalent3);
        if (simpleTalent4 == null)
            transform.Find("SimpleTalent4").TryGetComponent<UISimpleTalent>(out simpleTalent4);
        if (simpleTalent5 == null)
            transform.Find("SimpleTalent5").TryGetComponent<UISimpleTalent>(out simpleTalent5);
        if (simpleTalent6 == null)
            transform.Find("SimpleTalent6").TryGetComponent<UISimpleTalent>(out simpleTalent6);
        if (simpleTalent7 == null)
            transform.Find("SimpleTalent7").TryGetComponent<UISimpleTalent>(out simpleTalent7);
        if (simpleTalent8 == null)
            transform.Find("SimpleTalent8").TryGetComponent<UISimpleTalent>(out simpleTalent8);

        if (complexTalent1 == null)
            transform.Find("ComplexTalent1").TryGetComponent<UIComplexTalent>(out complexTalent1);
        if (complexTalent2 == null)
            transform.Find("ComplexTalent1").TryGetComponent<UIComplexTalent>(out complexTalent2);

        simpleTalents = new List<UISimpleTalent>() { simpleTalent1, simpleTalent2, simpleTalent3, simpleTalent4, simpleTalent5, simpleTalent6, simpleTalent7, simpleTalent8 };
        complexTalents = new List<UIComplexTalent>() { complexTalent1, complexTalent2 };


        SetRune(NewRune());

    }

    public void SetRune(LocusRune nR)
    {
        LocusRune = nR;

        for (int i = 0; i < simpleTalents.Count; i++)
        {
            if(nR.simpleTalents.Count > i)
            {
                simpleTalents[i].Initialize(nR.simpleTalents[i]);
                simpleTalents[i].gameObject.SetActive(true);
            }
            else
                simpleTalents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < complexTalents.Count; i++)
        {
            if (nR.complexTalents.Count > i)
            {
                complexTalents[i].Initialize(nR.complexTalents[i]);
                complexTalents[i].gameObject.SetActive(true);
            }
            else
                complexTalents[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < LocusRune.simpleTalents.Count; i++)
        {
            simpleTalents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos(360 / LocusRune.simpleTalents.Count * i * Mathf.Deg2Rad), 100 * Mathf.Sin(360 / LocusRune.simpleTalents.Count * i * Mathf.Deg2Rad));
        }

        if (complexTalents.Count == 1)
        {
            complexTalent1.transform.position = transform.position + new Vector3(0,-150);
        }
        else if (complexTalents.Count == 2)
        {
            complexTalent1.transform.position = transform.position + new Vector3(-150, -150);
            complexTalent2.transform.position = transform.position + new Vector3(150, -150);
        }
    }

    public void ConnectNorth()
    {
        if (connectorNorth.attachedlocusRune == null)
        {
            GameObject newRune = Instantiate(Resources.Load("Prefabs/UIComponents/Talents/LocusRune")) as GameObject;
            connectorNorth.attachedlocusRune = newRune.GetComponent<UILocusRune>();
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
            newRune.GetComponent<UILocusRune>().LocusRune = NewRune();
            newRune.transform.SetParent(characterTalents.talentContent.transform);
            newRune.transform.position = GetComponent<RectTransform>().position + positionWest;
        }
    }

    public LocusRune NewRune()
    {
        return new LocusRune()
        {
            simpleTalents = new List<SimpleTalent>() {
                new SimpleTalent() { talentName = "talent1", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent2", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Arcane, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent3", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent4", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Earth, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent5", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Electricity, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent6", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Ethereal, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent7", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent8", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } }

            },
            complexTalents = new List<ComplexTalent>()
            {
                new CT_ExplosiveFireOrb(),
                new CT_HotColdSwap()
            }
        };
    }
}