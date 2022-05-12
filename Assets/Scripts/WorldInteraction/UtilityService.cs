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
            case Rune.FormRuneTag.Beam:
                {
                    return false;
                }
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
            default:
                break;
        }
        return false;
    }

    public static Vector3 LineOfSightCheckRootUnit(Vector3 viewerEyes, RootCharacter subject)
    {
        RaycastHit lineOfSightTop;
        RaycastHit lineOfSightCenter;
        RaycastHit lineOfSightBottom;
        RaycastHit lineOfSightFront;
        RaycastHit lineOfSightBack;
        RaycastHit lineOfSightLeft;
        RaycastHit lineOfSightRight;

        var mesh = subject.GetComponent<CapsuleCollider>();
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(0, mesh.height, 0), Color.red);
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(0, mesh.height / 2, 0), Color.green);
        Debug.DrawLine(viewerEyes, subject.transform.position, Color.blue);
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(0, mesh.height / 2, mesh.radius), Color.black);
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(0, mesh.height, -mesh.radius), Color.white);
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(-mesh.radius, mesh.height, 0), Color.gray);
        Debug.DrawLine(viewerEyes, subject.transform.position + new Vector3(mesh.radius, mesh.height, 0), Color.cyan);

        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(0, mesh.height, 0) - viewerEyes, out lineOfSightCenter, 50);
        if (lineOfSightCenter.collider.GetComponent<RootCharacter>())
            return lineOfSightCenter.point;
        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(0, mesh.height / 2, 0) - viewerEyes, out lineOfSightTop, 50);
        if (lineOfSightTop.collider.GetComponent<RootCharacter>())
            return lineOfSightTop.point;
        Physics.Raycast(viewerEyes, subject.transform.position - viewerEyes, out lineOfSightBottom, 50);
        if (lineOfSightBottom.collider.GetComponent<RootCharacter>())
            return lineOfSightBottom.point;
        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(0, mesh.height / 2, mesh.radius) - viewerEyes, out lineOfSightFront, 50);
        if (lineOfSightFront.collider.GetComponent<RootCharacter>())
            return lineOfSightFront.point;
        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(0, mesh.height, -mesh.radius) - viewerEyes, out lineOfSightBack, 50);
        if (lineOfSightBack.collider.GetComponent<RootCharacter>())
            return lineOfSightBack.point;
        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(-mesh.radius, mesh.height, 0) - viewerEyes, out lineOfSightLeft, 50);
        if (lineOfSightLeft.collider.GetComponent<RootCharacter>())
            return lineOfSightLeft.point;
        Physics.Raycast(viewerEyes, subject.transform.position + new Vector3(mesh.radius, mesh.height, 0) - viewerEyes, out lineOfSightRight, 50);
        if (lineOfSightRight.collider.GetComponent<RootCharacter>())
            return lineOfSightRight.point;

        return new Vector3();
    }

    /*
     * The MIT License (MIT)

    Copyright (c) 2008 Daniel Brauer

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
    to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
     */
    // Calculating Lead For Projectiles
    //Author: Daniel Brauer
    //UnifyWiki
    //Methods FirstOrderIntecept() and FirstOrderInterceptTime()
    //first-order intercept using absolute target position
    public static Vector3 FirstOrderIntercept(Vector3 shooterPosition, Vector3 shooterVelocity, float shotSpeed, Vector3 targetPosition, Vector3 targetVelocity)
    {
        Vector3 targetRelativePosition = targetPosition - shooterPosition;
        Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
        float t = FirstOrderInterceptTime
        (
            shotSpeed,
            targetRelativePosition,
            targetRelativeVelocity
        );
        return targetPosition + t * (targetRelativeVelocity);
    }
    //first-order intercept using relative target position
    public static float FirstOrderInterceptTime(float shotSpeed, Vector3 targetRelativePosition, Vector3 targetRelativeVelocity)
    {
        float velocitySquared = targetRelativeVelocity.sqrMagnitude;
        if (velocitySquared < 0.001f)
            return 0f;

        float a = velocitySquared - shotSpeed * shotSpeed;

        //handle similar velocities
        if (Mathf.Abs(a) < 0.001f)
        {
            float t = -targetRelativePosition.sqrMagnitude /
            (
                2f * Vector3.Dot
                (
                    targetRelativeVelocity,
                    targetRelativePosition
                )
            );
            return Mathf.Max(t, 0f); //don't shoot back in time
        }

        float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
        float c = targetRelativePosition.sqrMagnitude;
        float determinant = b * b - 4f * a * c;

        if (determinant > 0f)
        { //determinant > 0; two intercept paths (most common)
            float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
                    t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
            if (t1 > 0f)
            {
                if (t2 > 0f)
                    return Mathf.Min(t1, t2); //both are positive
                else
                    return t1; //only t1 is positive
            }
            else
                return Mathf.Max(t2, 0f); //don't shoot back in time
        }
        else if (determinant < 0f) //determinant < 0; no intercept path
            return 0f;
        else //determinant = 0; one intercept path, pretty much never happens
            return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
    }
}