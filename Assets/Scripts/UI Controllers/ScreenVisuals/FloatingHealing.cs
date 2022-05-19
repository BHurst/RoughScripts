using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealing : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public float timer = 0;
    public float fadeMod = .9f;
    public float Alpha = 0;
    public CanvasRenderer CR;
    public bool active = false;

    private void Start()
    {
        CR = GetComponent<CanvasRenderer>();
        damageText = GetComponent<TextMeshProUGUI>();
    }

    public void Disappear()
    {
        CR.SetAlpha(0);
        active = false;
        damageText.text = "0";
    }

    public void AddHit(float value)
    {
        if (timer >= 2)
        {
            active = true;
            CR.SetAlpha(0);
        }
        damageText.text = Mathf.Round((float.Parse(damageText.text) + value)).ToString();
        Alpha = 1;
        CR.SetAlpha(Alpha);
        timer = 0;
    }

    public void UpdateHealing(Vector3 location)
    {
        timer += Time.deltaTime;

        if (timer > 0)
        {
            if (timer <= 2)
            {
                if (timer < 1.5)
                {
                    CR.SetAlpha(Alpha);
                    transform.position = (Vector2)location;
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