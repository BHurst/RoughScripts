using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public float timer = 0;
    public float fadeMod = .9f;
    public float Alpha = 0;
    public CanvasRenderer CR;
    public bool active = false;
    public float shakePower = 30;

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
    }

    public void AddHit(float value, float power)
    {
        if (!active)
        {
            active = true;
            CR.SetAlpha(0);
        }
        damageText.text = Mathf.Round((float.Parse(damageText.text) + value)).ToString();
        Alpha = 1;
        if (power > .05f && power < .1f)
            shakePower = .33f;
        else if (power > .1f && power < .2f)
            shakePower = .66f;
        else if (power > .2f)
            shakePower = 0f;
        else
            shakePower = 1;
        CR.SetAlpha(Alpha);
        timer = 0;
    }

    public void UpdateDamage(Vector3 location)
    {
        timer += Time.deltaTime;

        if (timer > 0)
        {
            if (timer <= 2)
            {
                if (timer < 1.5)
                {
                    CR.SetAlpha(Alpha);
                    if (timer < .15)
                        transform.position = (Vector2)location + new Vector2(Random.Range(-30 + timer * 200, 30 - timer * 200) * shakePower, Random.Range(-30 + timer * 200, 30 - timer * 200) * shakePower);
                    else
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