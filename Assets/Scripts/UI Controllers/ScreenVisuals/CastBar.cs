using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour {

    public Image bar;

    public void CastUpdate(float castPercent)
    {
        bar.fillAmount = castPercent;
        if (castPercent >= 1)
            bar.fillAmount = 0;
    }
}