using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour {

    public Image bar;
    public TextMeshProUGUI text;

    public void CastUpdate(float castPercent, float timeLeft, bool showWhenFull)
    {
        bar.fillAmount = castPercent;
        text.text = string.Format("{0:#.0}", timeLeft <= 0 ? "" : timeLeft);
        if ((castPercent >= 1 && showWhenFull == false) || (timeLeft <= 0 && showWhenFull == false))
        {
            bar.fillAmount = 0;
            text.text = "";
        }
    }
}