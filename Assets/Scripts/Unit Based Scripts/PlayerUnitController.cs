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
    float pushTime = 0;
    bool grounded = true;
    public static bool faceForward = false;
    public static float facingAngle = 0f;
    public Vector3 velocity;
    public float drag = 45f;
    public Vector3 fullSpeed;
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
    void PushCheck()
    {
        if (player.pushedBeyondMaxSpeed)
        {
            pushTime += Time.deltaTime;
            //Check if player speed has been brought below their "normal movement" threshold to then treat movement as normal again
            if (pushTime > .25f)
                if ((speedMagnitude < player.totalStats.MovementSpeed_Current && player.sprintState != SprintState.Sprinting) || (speedMagnitude < player.totalStats.MovementSpeed_Current * (1 + player.totalStats.Sprint_Rate_AddPercent.value) && player.sprintState == SprintState.Sprinting))
                {
                    player.pushedBeyondMaxSpeed = false;
                    pushTime = 0;
                }
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
            playerBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            timeSinceLastJump = 0;
            jumpCount--;
        }
    }

    public void Interact()
    {
        if (closestItem != null)
        {
            player.charInventory.PickUp(closestItem.GetComponent<WorldItem>());
            closestItem = null;
        }
    }

    public void ItemCheck()
    {
        closestItem = UtilityService.ClosestObject(playerTransform.position, 2, 1 << 10);
        if(closestItem != null)
        {
            closestItem.TryGetComponent<WorldItem>(out var nearItem);
            if (nearItem != null)
            {
                nearItem.SetTooltipInfo();
                nearItem.tooltipInfo.Activate();
            }
            else
                WorldObjectTooltipController.Hide();
        }
        else
            WorldObjectTooltipController.Hide();
    }

    void FixedUpdate()
    {
        ItemCheck();
        PushCheck();
        GroundCheck();
        timeSinceLastJump += Time.deltaTime;
        speedMagnitude = new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z).magnitude;

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


            fullSpeed *= player.totalStats.MovementSpeed_Current;
            if (player.sprintState == SprintState.Sprinting)
                fullSpeed *= 1 + player.totalStats.Sprint_Rate_AddPercent.value;

            playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, Quaternion.LookRotation(new Vector3(directionalSpeed.x, 0, directionalSpeed.z), playerBody.transform.up), 780f * Time.deltaTime);

            //WIP--Problem: slow player when moving too fast. Can't seem to do this nicely(slows too fast/doesn't slow enough/Not consistent)

            //I don't know what the math is that is going on here, but anything below 42 for speed doesn't move when mass is 1.
            fullSpeed += fullSpeed.normalized * 42f * 50 * Time.deltaTime;

            if (grounded)
            {
                if (playerBody.velocity.magnitude < (fullSpeed.magnitude - 42) * .85f)
                    playerBody.AddForce(fullSpeed * 3, ForceMode.Force);
                else if (player.pushedBeyondMaxSpeed)
                    playerBody.AddForce(playerBody.velocity * -.3f, ForceMode.Force);
                else
                    playerBody.AddForce(fullSpeed - playerBody.velocity, ForceMode.Force);
            }

            //Apply a faux friction to bring a player going too fast back into normal speed
            if (player.pushedBeyondMaxSpeed && grounded)
            {
                
            }
        }

        //Cap falling speed
        if (playerBody.velocity.y < -54)//Terminal velocity, essentially
            playerBody.velocity = new Vector3() { x = playerBody.velocity.x, y = playerBody.velocity.y * .99f, z = playerBody.velocity.z };

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