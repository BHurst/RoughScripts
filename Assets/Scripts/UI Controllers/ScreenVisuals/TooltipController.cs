using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TooltipController : MonoBehaviour
{
    public static TooltipController main;
    public Tooltip tooltip;
    public float timer = 0;
    public float delayTime = 1;
    public CanvasGroup canv;
    bool hovering = false;

    private void Awake()
    {
        main = this;
    }

    public static void Show(string headerContent, string shorthandContent, string bodyContent, string tertiaryContent)
    {
        main.tooltip.SetText(headerContent, shorthandContent, bodyContent, tertiaryContent);

        main.hovering = true;
    }

    public static void Hide()
    {
        main.hovering = false;
        main.timer = 0;
        main.canv.alpha = 0;
    }

    //Manipulates a text box to display the name of a object/character when moused over for a short period of time.
    void Update()
    {
        if (main.hovering)
            timer = Mathf.Clamp01(timer += Time.deltaTime);
        if (timer > .5f && canv.alpha < 1)
        {
            canv.alpha = (timer - .5f) * 4;
        }
    }
}