using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityService : MonoBehaviour {

    static GameObject closestObject;
    static Collider[] pickupSphere;

    public static GameObject ClosestObject(Vector3 CenterPoint, float Radius, int LayerMask)
    {
        closestObject = null;
        pickupSphere = Physics.OverlapSphere(CenterPoint, Radius, LayerMask);

        if (pickupSphere.Length > 0)
        {
            int closestIndex = -1;
            float closestDistance = 10000f;
            foreach (Collider c in pickupSphere)
            {
                if (Vector3.Distance(c.transform.position, CenterPoint) < closestDistance)
                {
                    closestDistance = (Vector3.Distance(c.transform.position, CenterPoint));
                    closestIndex = Array.IndexOf(pickupSphere, c);
                }
            }

            if (closestIndex != -1)
            {
                closestObject = pickupSphere[closestIndex].gameObject;
            }
        }

        if (closestObject != null)
            return closestObject;
        else
            return null;
    }

    public static string TimerFormatter(float secs)
    {
        TimeSpan t = TimeSpan.FromSeconds(secs);
        string result;

        if (t.TotalSeconds < 60)
            result = string.Format("{0}s", t.Seconds);
        else if (t.TotalMinutes < 60)
            result = string.Format("{0}m {1}s", t.Minutes, t.Seconds);
        else
            result = string.Format("{0}h {1}m", t.Hours, t.Minutes);

        return result;
    }
}