using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    public float timer = 0;
    public FloatingTextType textType = FloatingTextType.Basic;
    public float fadeMod = .9f;
    public float riseMod = 6f;
    public float xDev = 0;
    public float yDev = 0;
    public float zDev = 0;
    public float Alpha = 0;
    float scaleChange = 1;
    CanvasRenderer CR;
    public Transform unitTotrack;

    private void Start()
    {
        CR = GetComponent<CanvasRenderer>();
        Alpha = CR.GetAlpha();
    }

    private void HandleDistance()
    {
        scaleChange = Mathf.Log(Vector3.Distance(GameWorldReferenceClass.GW_PlayerCamera.transform.position, transform.position), 20);
        transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange);
    }

    private void OnEnable()
    {
        Alpha = 1;
        timer = 0;
        HandleDistance();
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    public void ResetOnDamage()
    {
        Alpha = 1;
        CR.SetAlpha(Alpha);
        timer = 0;
        HandleDistance();
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.position = unitTotrack.position + new Vector3(xDev, yDev, zDev);
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        timer += Time.deltaTime;

        HandleDistance();

        if (textType == FloatingTextType.Damage)
        {
            if (timer < .15)
            {
                transform.position = unitTotrack.position + new Vector3(xDev + Random.Range(-.3f + timer * 2, .3f - timer * 2), yDev + Random.Range(-.3f + timer * 2, .3f - timer * 2), zDev);
            }
            if (timer > .15 && timer < 1.5)
            {
                transform.position = unitTotrack.position + new Vector3(xDev, yDev, zDev);
            }
            if (timer >= 1.5)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime, zDev);
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 2)
            {
                ResourceManager.HideDamageText(this.gameObject);
            }
        }
        else if (textType == FloatingTextType.Heal)
        {
            if (timer < 1.5)
            {
                transform.position = unitTotrack.position + new Vector3(xDev, yDev, zDev);
            }
            if (timer >= 1.5)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime, zDev);
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 2)
            {
                ResourceManager.HideDamageText(this.gameObject);
            }
        }
        else if (textType == FloatingTextType.Buff)
        {
            if (timer < .8f)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime + yDev, zDev);
            }
            if (timer >= .8f)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime + yDev, zDev);
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 1.3f)
            {
                ResourceManager.HideDamageText(this.gameObject);
            }
            riseMod -= 2.8f * Time.deltaTime;
            if (riseMod <= 0)
                riseMod = 0;
        }
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    public void DetermineType(FloatingTextType type)
    {
        textType = type;
        if (type == FloatingTextType.Damage)
        {
            xDev = 0;
            yDev = 1;
            zDev = 0;
            riseMod = -2.5f;
        }
        if (type == FloatingTextType.Heal)
        {
            xDev = 0;
            yDev = 2f;
            zDev = 0;
            riseMod = 2.5f;
        }
        if (type == FloatingTextType.Buff)
        {
            xDev = 0;
            yDev = 0;
            zDev = 0;
            riseMod = 4f;
        }
        if (type == FloatingTextType.Basic)
        {
            xDev = 0;
            yDev = 1;
            zDev = 0;
            riseMod = 1.5f;
        }
    }

    public enum FloatingTextType
    {
        Damage,
        Heal,
        Buff,
        Basic
    }
}