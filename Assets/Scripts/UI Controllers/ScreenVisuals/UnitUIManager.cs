using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitUIManager : MonoBehaviour
{
    public Transform anchor;
    public Transform parentPane;
    public FloatingDamage floatingDamage;
    public FloatingHealing floatingHealing;
    public EnemyHealthBar enemyHealthBar;
    public CanvasGroup canv;
    float scaleChange = 1;
    public Vector3 location;
    public float distance;
    Vector3 viewportPoint;

    public void DelayedStart(Transform anchor, FloatingDamage dmgText, FloatingHealing healText, CanvasGroup canvasGroup)
    {
        this.anchor = anchor;
        floatingDamage = dmgText;
        floatingHealing = healText;
        canv = canvasGroup;
        UnitUIManagerSorter.main.unitUIs.Add(this);
    }

    public void Show()
    {
        canv.alpha = 1;
    }

    public void Hide()
    {
        if (canv != null)
            canv.alpha = 0;
    }

    public void Dissapear()
    {
        floatingDamage.Disappear();
        floatingHealing.Disappear();
        enemyHealthBar.Disappear();
    }

    private void HandleDistance()
    {
        scaleChange = Mathf.Clamp(1 - ((Mathf.Abs(location.z) - 10) * .025f), .5f, 1);
        parentPane.transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange);
    }

    private void Update()
    {
        location = Camera.main.WorldToScreenPoint(anchor.position);
        parentPane.position = location;
        HandleDistance();
        distance = Vector3.Distance(anchor.position, PlayerCharacterUnit.player.transform.position);
        
        if (location.z > 0)
            Show();
        else
            Hide();

        if (floatingDamage.active && floatingHealing.active)
        {
            floatingDamage.UpdateDamage(location + new Vector3(50, 50, 0));
            floatingHealing.UpdateHealing(location + new Vector3(-50, 50, 0));
        }
        else
        {
            if (floatingDamage.active)
                floatingDamage.UpdateDamage(location + new Vector3(0, 50, 0));
            if (floatingHealing.active)
                floatingHealing.UpdateHealing(location + new Vector3(0, 50, 0));
        }
        enemyHealthBar.UpdateEnemyHealthBar();
    }
}