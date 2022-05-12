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
    RaycastHit groundAdheranceNormal = new RaycastHit();

    private void Awake()
    {
        playerTransform = GameObject.Find("PlayerData").GetComponent<Transform>();
        playerBody = GameObject.Find("PlayerData").GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        playerCollider = GameObject.Find("PlayerData").GetComponent<Collider>();
    }

    void GroundCheck()
    {
        var hitBelow = Physics.OverlapSphere(playerTransform.position, .15f, 1 << 9);
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
            playerBody.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
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
        playerStatIncreasedSpeed = player.totalStats.MoveSpeed.value * player.totalStats.MoveSpeed_Rate_AddPercent.value * player.totalStats.MoveSpeed_Rate_MultiplyPercent.value;

        //Movement control based on input
        if (moveInput != new Vector2())
        {
            directionalSpeed = new Vector3();

            directionalSpeed.x = moveInput.x;
            directionalSpeed.z = moveInput.y;

            directionalSpeed = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * directionalSpeed;
            directionalSpeed.Normalize();

            Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), Vector3.down, out groundAdherance, .4f, 1 << 9);

            //Change directional force to be in line with the surface
            fullSpeed = directionalSpeed - Vector3.Dot(directionalSpeed, groundAdherance.normal) * groundAdherance.normal;
            Debug.DrawRay(playerBody.transform.position, fullSpeed);

            fullSpeed *= playerStatIncreasedSpeed;
            if (player.sprintState == SprintState.Sprinting)
                fullSpeed *= player.totalStats.SprintSpeed_Rate_AddPercent.value;

            playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, Quaternion.LookRotation(new Vector3(directionalSpeed.x, 0, directionalSpeed.z), playerBody.transform.up), 780f * Time.deltaTime);

            //WIP--Problem: slow player when moving too fast. Can't seem to do this nicely(slows too fast/doesn't slow enough/Not consistent)
            if (!player.pushedBeyondMaxSpeed)
            {
                float max = playerStatIncreasedSpeed;
                if (player.sprintState == SprintState.Sprinting)
                    max *= player.totalStats.SprintSpeed_Rate_AddPercent.value;
                if (player.actionState == ActionState.Casting)
                    max *= player.totalStats.CastmoveSpeed_Rate_MultiplyPercent.value;

                if (speedMagnitude < playerStatIncreasedSpeed && player.movementState == MovementState.Moving)
                {
                    if (grounded)
                        playerBody.AddForce(fullSpeed * 10, ForceMode.Force);
                    else
                        playerBody.AddForce(fullSpeed, ForceMode.Force);
                    //Vector2 capped = Vector2.ClampMagnitude(new Vector2() { x = playerBody.velocity.x, y = playerBody.velocity.z }, max);
                    //playerBody.velocity = new Vector3() { x = capped.x, y = playerBody.velocity.y, z = capped.y };
                }
            }
        }

        //Check if player speed has been brought below their "normal movement" threshold to then treat movement as normal again
        if ((speedMagnitude < playerStatIncreasedSpeed && player.sprintState != SprintState.Sprinting) || (speedMagnitude < playerStatIncreasedSpeed * player.totalStats.SprintSpeed_Rate_AddPercent.value && player.sprintState == SprintState.Sprinting))
            player.pushedBeyondMaxSpeed = false;

        //Apply a faux friction to bring a player going too fast back into normal speed
        if (player.pushedBeyondMaxSpeed && grounded)
        {
            velocity = playerBody.velocity;
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, 1f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, 1f);
            playerBody.velocity = velocity;
        }

        //Slow the player when no movement input
        if (!player.pushedBeyondMaxSpeed && grounded && moveInput == new Vector2())
        {
            playerBody.velocity = new Vector3(playerBody.velocity.x * .8f, playerBody.velocity.y, playerBody.velocity.z * .8f);
        }

        //Clamp the player speed to prevent exceeding max speed under normal conditions
        if(!player.pushedBeyondMaxSpeed)
        {
            
        }

        if (!grounded)
        {
            velocity = playerBody.velocity;
            velocity.x = velocity.x * .998f;
            velocity.z = velocity.z * .998f;
            playerBody.velocity = velocity;
        }

        //Make sure the player stays stuck to the ground unless pushed. This works, for some reason. No side effects at the moment
        if (grounded && !player.pushedBeyondMaxSpeed && timeSinceLastJump > .5f)
        {
            //playerBody.velocity = new Vector3(playerBody.velocity.x * groundInvertedNormal.x, playerBody.velocity.y * groundInvertedNormal.y, playerBody.velocity.z * groundInvertedNormal.z);
            //if (Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), -groundAdherance.normal, out groundAdheranceNormal, .2f, 1 << 9))
            playerBody.AddForce(-groundAdherance.normal, ForceMode.Impulse);
            //playerBody.position = Vector3.Slerp(playerBody.position, groundAdherance.point, 1);// I feel like this shouldn't work but, whatever
        }
    }
}