using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDisplayIcon : MonoBehaviour
{
    public Image buffImage;
    public Text buffTimer;
    public int buffSource;
    public float buffDuration = 0;

    void Update()
    {
        buffDuration -= Time.deltaTime;

        if (buffDuration <= 0)
            Destroy(this.gameObject);
        else
        {
            buffTimer.text = UtilityService.TimerFormatter(buffDuration);
        }
    }
}