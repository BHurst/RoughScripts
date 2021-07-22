using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour {

    public Image bar;
    public TextMeshProUGUI text;

    public void CastUpdate(float castPercent, float timeLeft)
    {
        bar.fillAmount = castPercent;
        text.text = string.Format("{0:#.0}", timeLeft);
        if (castPercent >= 1 || timeLeft <= 0)
        {
            bar.fillAmount = 0;
            text.text = "";
        }
    }
}