using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daytime : MonoBehaviour
{
    public static float timeOfDay = 7200;
    public static float timeInDay = 21600;
    public static float hours = 0;
    public static float minutes = 0;
    public static float seconds = 0;
    public enum DayState { Sunrise, Morning, Noon, Afternoon, Night, Midnight }

    public GameObject clock;
    
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        timeOfDay += Time.deltaTime;
        seconds = Mathf.Floor(timeOfDay / timeInDay * 86400) % 60;
        minutes = Mathf.Floor(timeOfDay / timeInDay * 1440) % 60;
        hours = Mathf.Floor(timeOfDay / timeInDay * 24);

        transform.localEulerAngles = new Vector3((timeOfDay / timeInDay * 360f) - 90, 30f, 0f);

        if (timeOfDay >= timeInDay)
            timeOfDay = 0;

        clock.GetComponent<Text>().text = hours.ToString().PadLeft(2, '0') + ":" + minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
    }

    public static void Sunrise()
    {
        timeOfDay = timeInDay * .25f;
    }

    public static void Morning()
    {
        timeOfDay = timeInDay * .33333333f;
    }

    public static void Noon()
    {
        timeOfDay = timeInDay * .5f;
    }

    public static void Evening()
    {
        timeOfDay = timeInDay * .66666666f;
    }

    public static void Sunset()
    {
        timeOfDay = timeInDay * .75f;
    }

    public static void Midnight()
    {
        timeOfDay = 0;
    }

}