using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFloatingDamageTaken : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public float timer = 0;
    public float fadeMod = .9f;
    public float Alpha = 0;
    public CanvasRenderer CR;
    public bool active = false;
    public float currentlyTrackedDamage = 0;

    private void Start()
    {
        CR = GetComponent<CanvasRenderer>();
        CR.SetAlpha(0);
        damageText = GetComponent<TextMeshProUGUI>();
        damageText.text = "0";
    }

    public void Disappear()
    {
        CR.SetAlpha(0);
        active = false;
        damageText.text = "0";
        currentlyTrackedDamage = 0;
    }

    public void AddHit(float value)
    {
        if (!active)
        {
            active = true;
            CR.SetAlpha(0);
        }
        currentlyTrackedDamage += value;
        damageText.text = Mathf.Round(currentlyTrackedDamage).ToString();
        Alpha = 1;
        CR.SetAlpha(Alpha);
        timer = 0;
        if (currentlyTrackedDamage < 0)
            damageText.color = Color.red;
        else
            damageText.color = Color.green;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0)
        {
            if (timer <= 2)
            {
                if (timer < 1.5)
                {
                    CR.SetAlpha(Alpha);
                }
                else
                {
                    Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                    CR.SetAlpha(Alpha);
                }
            }
            else
            {
                Disappear();
            }
        }

    }
}