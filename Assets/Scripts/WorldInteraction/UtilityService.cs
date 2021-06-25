using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityService : MonoBehaviour
{

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

    internal static Vector3 LimitVector3XZ(Vector3 velocity, float moveSpeed)
    {
        Vector3 temp = velocity;
        float mag = Mathf.Sqrt(velocity.x * velocity.x + velocity.z * velocity.z);

        if (mag > moveSpeed)
        {
            temp = new Vector3(velocity.x / mag * moveSpeed, velocity.y, velocity.z / mag * moveSpeed);
        }

        return temp;
    }

    public static bool CanFormTriggerForm(Rune.FormRuneTag abilityTriggering, Rune.FormRuneTag abilityBeingTriggered)
    {
        //Layers of abilities will be able to trigger the next. One way only. Bottom tier cannot trigger or be triggered
        //Orb, Lance, Point, SelfCast, Weapon
        //Arc, Nova
        //Strike
        //Zone
        //----------
        //Aura, Beam, Wave
        //Command is special and can trigger everything except Aura, Zone, and Weapon but cannot be triggered
        if (abilityTriggering == Rune.FormRuneTag.Zone || abilityBeingTriggered == Rune.FormRuneTag.Aura)
            return false;
        switch (abilityTriggering)
        {
            case Rune.FormRuneTag.Arc:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Aura:
                {
                    return false;
                }
                break;
            case Rune.FormRuneTag.Beam:
                {
                    return false;
                }
                break;
            case Rune.FormRuneTag.Command:
                {
                    if (abilityBeingTriggered != Rune.FormRuneTag.Aura && abilityBeingTriggered != Rune.FormRuneTag.Zone && abilityBeingTriggered != Rune.FormRuneTag.Weapon)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Lance:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Arc || abilityBeingTriggered == Rune.FormRuneTag.Nova || abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Nova:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Orb:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Arc || abilityBeingTriggered == Rune.FormRuneTag.Nova || abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Point:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Arc || abilityBeingTriggered == Rune.FormRuneTag.Nova || abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.SelfCast:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Arc || abilityBeingTriggered == Rune.FormRuneTag.Nova || abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Strike:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Wave:
                {
                    return false;
                }
                break;
            case Rune.FormRuneTag.Weapon:
                {
                    if (abilityBeingTriggered == Rune.FormRuneTag.Arc || abilityBeingTriggered == Rune.FormRuneTag.Nova || abilityBeingTriggered == Rune.FormRuneTag.Strike || abilityBeingTriggered == Rune.FormRuneTag.Zone)
                        return true;
                }
                break;
            case Rune.FormRuneTag.Zone:
                {
                    return false;
                }
                break;
            default:
                break;
        }
        return false;
    }
}