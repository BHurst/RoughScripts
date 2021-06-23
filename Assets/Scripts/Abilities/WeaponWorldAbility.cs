using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWorldAbility_OLD
{
    //This is temporary for retaining how I track collisions under low frame rate

    //void LateUpdate()
    //{
    //    if (stats.abilityTags.Contains(SpellStats.AbilityTag.Attack))
    //    {
    //        transform.position = ownersWeapon.position;
    //        transform.rotation = ownersWeapon.rotation;
    //        transform.localScale = ownersWeapon.localScale;
    //    }

    //    if (stats.weaponSwingActivation <= activationTimer && stats.weaponSwingDeactivation >= activationTimer)
    //    {
    //        if (!started)
    //        {
    //            previousFramePosition = transform.position;
    //            previousFrameRotation = ownersWeapon.rotation;
    //            started = true;
    //        }
    //        else
    //        {
    //            weaponHit = Physics.BoxCastAll(previousFramePosition, ownersWeapon.localScale / 2, ownersWeapon.position - previousFramePosition, previousFrameRotation, Vector3.Distance(ownersWeapon.position, previousFramePosition));


    //            foreach (RaycastHit hit in weaponHit)
    //            {
    //                if (hit.collider.GetComponent<RootUnit>())
    //                    Kolide(hit.collider);
    //            }

    //            DrawCubePoints(CubePoints(previousFramePosition, ownersWeapon.localScale / 2, previousFrameRotation));
    //            ExtDebug.DrawBoxCastBox(previousFramePosition, ownersWeapon.localScale / 2, previousFrameRotation, ownersWeapon.position - previousFramePosition, Vector3.Distance(ownersWeapon.position, previousFramePosition), Color.red);
    //            previousFramePosition = transform.position;
    //            previousFrameRotation = ownersWeapon.rotation;
    //            DrawCubePoints(CubePoints(previousFramePosition, ownersWeapon.localScale / 2, previousFrameRotation));
    //        }
    //    }
    //}

    //Vector3[] CubePoints(Vector3 center, Vector3 extents, Quaternion rotation)
    //{
    //    Vector3[] points = new Vector3[8];
    //    points[0] = rotation * Vector3.Scale(extents, new Vector3(1, 1, 1)) + center;
    //    points[1] = rotation * Vector3.Scale(extents, new Vector3(1, 1, -1)) + center;
    //    points[2] = rotation * Vector3.Scale(extents, new Vector3(1, -1, 1)) + center;
    //    points[3] = rotation * Vector3.Scale(extents, new Vector3(1, -1, -1)) + center;
    //    points[4] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, 1)) + center;
    //    points[5] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, -1)) + center;
    //    points[6] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, 1)) + center;
    //    points[7] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, -1)) + center;

    //    return points;
    //}

    //void DrawCubePoints(Vector3[] points)
    //{
    //    Debug.DrawLine(points[0], points[1]);
    //    Debug.DrawLine(points[0], points[2]);
    //    Debug.DrawLine(points[0], points[4]);

    //    Debug.DrawLine(points[7], points[6]);
    //    Debug.DrawLine(points[7], points[5]);
    //    Debug.DrawLine(points[7], points[3]);

    //    Debug.DrawLine(points[1], points[3]);
    //    Debug.DrawLine(points[1], points[5]);

    //    Debug.DrawLine(points[2], points[3]);
    //    Debug.DrawLine(points[2], points[6]);

    //    Debug.DrawLine(points[4], points[5]);
    //    Debug.DrawLine(points[4], points[6]);
    //}

    //void OnTriggerEnter(Collider collider)
    //{
    //    Kolide(collider);
    //}
}