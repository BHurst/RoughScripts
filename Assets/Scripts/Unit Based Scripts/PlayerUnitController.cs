using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerUnitController : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody playerBody;
    public PlayerCharacterUnit player;
    public Collider playerCollider;
    public GameObject closestItem;
    float timeSinceLastJump = 0;
    bool grounded = true;
    public static bool faceForward = false;
    public static float facingAngle = 0f;
    public Vector3 velocity;
    public float drag = 45f;
    public Vector3 fullSpeed;
    public float playerStatIncreasedSpeed;
    public float disregardGroundTime = .2f;
    int jumpCount = 1;
    public Transform cameraFocus;
    float damperx = 0;
    float dampery = 0;
    float speedMagnitude = 0;
    Vector3 directionalSpeed = new Vector3();
    Vector2 moveInput = new Vector2();
    RaycastHit groundAdherance = new RaycastHit();

    void SetMainUnit(Transform unit)
    {
        playerTransform = unit;
        playerBody = unit.GetComponent<Rigidbody>();
        player = unit.GetComponent<PlayerCharacterUnit>();
        playerCollider = unit.GetComponent<Collider>();
    }

    void GroundCheck()
    {
        var hitBelow = Physics.OverlapSphere(playerTransform.position, .25f, 1 << 9);
        if (hitBelow.Length > 0 && timeSinceLastJump > disregardGroundTime)
        {
            jumpCount = 1;
            grounded = true;
        }
        else
        {
            jumpCount = 0;
            grounded = false;
        }
    }

    public void Move(Vector2 input)
    {
        moveInput = input;
    }

    public void Jump()
    {
        if (jumpCount > 0)
        {
            playerBody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            timeSinceLastJump = 0;
            jumpCount--;
        }
    }

    public void Interact()
    {
        closestItem = UtilityService.ClosestObject(playerTransform.position, 2, 1 << 10);
        if (closestItem != null)
        {
            player.charInventory.PickUp(closestItem.GetComponent<WorldItem>());
            closestItem = null;
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        timeSinceLastJump += Time.deltaTime;
        speedMagnitude = Mathf.Sqrt(playerBody.velocity.x * playerBody.velocity.x + playerBody.velocity.z * playerBody.velocity.z);
        playerStatIncreasedSpeed = player.totalStats.MoveSpeed * player.totalStats.MoveSpeed_Movement_AddPercent * player.totalStats.MoveSpeed_Movement_MultiplyPercent;

        //Movement control based on input
        if (moveInput != new Vector2())
        {
            directionalSpeed = new Vector3();

            directionalSpeed.x = moveInput.x;
            directionalSpeed.z = moveInput.y;

            directionalSpeed = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * directionalSpeed;
            directionalSpeed.Normalize();

            //Change directional force to be in line with the surface
            Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), Vector3.down, out groundAdherance, .2f, 1 << 9);
            Vector3 tempDir = new Vector3(1 - groundAdherance.normal.x, 1 - groundAdherance.normal.y, 1 - groundAdherance.normal.z);
            fullSpeed = new Vector3(directionalSpeed.x * tempDir.x, directionalSpeed.y * tempDir.y, directionalSpeed.z * tempDir.z);

            fullSpeed *= playerStatIncreasedSpeed;
            if (player.movementState == RootUnit.MovementState.Sprinting)
                fullSpeed *= player.totalStats.Movespeed_Sprint_AddPercent;
            else if (player.movementState == RootUnit.MovementState.Casting)
                fullSpeed *= player.totalStats.Movespeed_Cast_MultiplyPercent;

            //WIP--Problem: slow player when moving too fast. Can't seem to do this nicely(slows too fast/doesn't slow enough/Not consistent)
            if (!player.pushedEvenFurtherBeyond)
            {
                playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, Quaternion.LookRotation(directionalSpeed, playerBody.transform.up), 780f * Time.deltaTime);
                if (grounded)
                    playerBody.AddForce(fullSpeed * 10, ForceMode.Acceleration);
                else
                    playerBody.AddForce(fullSpeed, ForceMode.Acceleration);
            }
        }

        //Check if player speed has been brought below their "normal movement" threshold to then treat movement as normal again
        if ((speedMagnitude < playerStatIncreasedSpeed && player.movementState != RootUnit.MovementState.Sprinting) || (speedMagnitude < playerStatIncreasedSpeed * player.totalStats.Movespeed_Sprint_AddPercent && player.movementState == RootUnit.MovementState.Sprinting))
            player.pushedEvenFurtherBeyond = false;

        //Apply a faux friction to bring a player going to fast back into normal speed
        if (player.pushedEvenFurtherBeyond && grounded)
        {
            velocity = playerBody.velocity;
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, 1f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, 1f);
            playerBody.velocity = velocity;
        }

        //Slow the player when no movement input
        if (!player.pushedEvenFurtherBeyond && grounded && moveInput == new Vector2())
        {
            playerBody.velocity = new Vector3(playerBody.velocity.x * .8f, playerBody.velocity.y, playerBody.velocity.z * .8f);
        }

        //Clamp the player speed to prevent exceeding max speed under normal conditions
        if (!player.pushedEvenFurtherBeyond && (speedMagnitude > playerStatIncreasedSpeed && player.movementState == RootUnit.MovementState.Idle))
        {
            Vector2 capped = Vector2.ClampMagnitude(new Vector2() { x = playerBody.velocity.x, y = playerBody.velocity.z }, playerStatIncreasedSpeed);
            playerBody.velocity = new Vector3() { x = capped.x, y = playerBody.velocity.y, z = capped.y };
        }
        else if (!player.pushedEvenFurtherBeyond && (speedMagnitude > playerStatIncreasedSpeed * player.totalStats.Movespeed_Sprint_AddPercent && player.movementState == RootUnit.MovementState.Sprinting))
        {
            Vector2 capped = Vector2.ClampMagnitude(new Vector2() { x = playerBody.velocity.x, y = playerBody.velocity.z }, playerStatIncreasedSpeed * player.totalStats.Movespeed_Sprint_AddPercent);
            playerBody.velocity = new Vector3() { x = capped.x, y = playerBody.velocity.y, z = capped.y };
        }
        else if (!player.pushedEvenFurtherBeyond && (speedMagnitude > playerStatIncreasedSpeed * player.totalStats.Movespeed_Cast_MultiplyPercent && player.movementState == RootUnit.MovementState.Casting))
        {
            Vector2 capped = Vector2.ClampMagnitude(new Vector2() { x = playerBody.velocity.x, y = playerBody.velocity.z }, playerStatIncreasedSpeed * player.totalStats.Movespeed_Cast_MultiplyPercent);
            playerBody.velocity = new Vector3() { x = capped.x, y = playerBody.velocity.y, z = capped.y };
        }

        if (!grounded)
        {
            velocity = playerBody.velocity;
            velocity.x = velocity.x * .998f;
            velocity.z = velocity.z * .998f;
            playerBody.velocity = velocity;
        }

        //Make sure the player stays stuck to the ground unless pushed. This works, for some reason. No side effects at the moment
        if (grounded && !player.pushedEvenFurtherBeyond)
        {
            if (Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), Vector3.down, out groundAdherance, .2f, 1 << 9))
                playerBody.position = Vector3.Slerp(playerBody.position, groundAdherance.point, 1);// I feel like this shouldn't work but, whatever
        }
    }
}