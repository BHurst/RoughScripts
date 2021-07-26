using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public CanvasRenderer CR;
    public Transform trackingPoint;

    private void Awake()
    {
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
        //Wait basically any amount longer than one frame to make visible, as you can see the text jerk around
        CR.SetAlpha(0);
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
        transform.position = trackingPoint.position + new Vector3(xDev, yDev, zDev);
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        timer += Time.deltaTime;

        HandleDistance();

        if (textType == FloatingTextType.Damage)
        {
            if(timer > 0 && timer < 1.5)
                CR.SetAlpha(Alpha);
            if (timer < .15)
                transform.position = trackingPoint.position + new Vector3(xDev + Random.Range(-.3f + timer * 2, .3f - timer * 2), yDev + Random.Range(-.3f + timer * 2, .3f - timer * 2), zDev + Random.Range(-.3f + timer * 2, .3f - timer * 2));
            if (timer > .15 && timer < 1.5)
                transform.position = trackingPoint.position + (trackingPoint.right / 2);
            if (timer > 1.5)
            {
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 2)
            {
                GetComponent<TextMeshProUGUI>().text = "0";
                gameObject.SetActive(false);
            }
        }
        else if (textType == FloatingTextType.Heal)
        {
            if (timer > 0 && timer < 1.5)
                CR.SetAlpha(Alpha);
            if (timer < 1.5)
                transform.position = trackingPoint.position + (-trackingPoint.right / 2);
            if (timer > 1.5)
            {
                Alpha = Alpha * fadeMod * (1 - Time.deltaTime);
                CR.SetAlpha(Alpha);
            }
            if (timer >= 2)
            {
                GetComponent<TextMeshProUGUI>().text = "0";
                gameObject.SetActive(false);
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
                gameObject.SetActive(false);
            }
            riseMod -= 2.8f * Time.deltaTime;
            if (riseMod <= 0)
                riseMod = 0;
        }
        //transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    public void DetermineType(FloatingTextType type)
    {
        textType = type;
        if (type == FloatingTextType.Damage)
        {
            xDev = .5f;
            yDev = 0;
            zDev = 0;
            riseMod = -2.5f;
        }
        if (type == FloatingTextType.Heal)
        {
            xDev = -.5f;
            yDev = 0f;
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