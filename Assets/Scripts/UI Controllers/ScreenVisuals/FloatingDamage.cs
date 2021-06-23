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

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        timer += Time.deltaTime;

        HandleDistance();

        if (textType == FloatingTextType.Basic)
        {
            if (timer < 1.5)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime + yDev, zDev);
            }
            if (timer >= 1.5)
            {
                transform.position += new Vector3(xDev, riseMod * Time.deltaTime + yDev, zDev);
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 2)
            {
                ResourceManager.HideDamageText(this.gameObject);
            }
            riseMod -= 2.8f * Time.deltaTime;
            if (riseMod <= 0)
                riseMod = 0;
        }
        else if(textType == FloatingTextType.Damage || textType == FloatingTextType.Heal)
        {
            if (timer < .8f)
            {
                transform.position += new Vector3(xDev * Time.deltaTime, riseMod * Time.deltaTime + yDev * Time.deltaTime, zDev * Time.deltaTime) * scaleChange;
            }
            if (timer >= .8f)
            {
                transform.position += new Vector3(xDev * Time.deltaTime, riseMod * Time.deltaTime + yDev * Time.deltaTime, zDev * Time.deltaTime) * scaleChange;
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 1)
            {
                ResourceManager.HideDamageText(this.gameObject);
            }
            riseMod -= 7f * Time.deltaTime;
        }
        else if(textType == FloatingTextType.Buff)
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
        if (type == FloatingTextType.Damage || type == FloatingTextType.Heal)
        {
            xDev = Random.Range(-1.05f, 1.05f);
            yDev = Random.Range(0f, 2.1f);
            zDev = Random.Range(-1.05f, 1.05f);
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
            yDev = 0;
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