using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SinglePlayerStatusIcon : MonoBehaviour
{
    public TMP_Text text;
    public Image image;
    public Status status;

    private void Update()
    {
        if (status.maxDuration > .5f)
            text.SetText(((int)status.currentDuration).ToString());
    }
}