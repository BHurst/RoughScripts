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
    float timeSinceGrounded = 0;
    bool grounded = true;
    public static bool faceForward = false;
    public static float facingAngle = 0f;
    public Vector3 velocity;
    public float drag = 45f;
    public float maxSpeed = 0f;
    public float disregardGroundTime = .2f;
    int jumpCount = 1;
    public Transform cameraFocus;
    float damperx = 0;
    float dampery = 0;
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
        float xBound = playerCollider.bounds.size.x / 2;
        float yBound = playerCollider.bounds.size.y / 2;
        float zBound = playerCollider.bounds.size.z / 2;

        var hitBelow = Physics.OverlapSphere(playerTransform.position, .25f, 1 << 9);
        if (hitBelow.Length > 0 && timeSinceLastJump > disregardGroundTime)
        {
            jumpCount = 1;
            grounded = true;
            timeSinceGrounded += Time.deltaTime;
        }
        else
        {
            jumpCount = 0;
            grounded = false;
            timeSinceGrounded = 0;
        }
    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
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

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GroundCheck();
        timeSinceLastJump += Time.deltaTime;


        if (moveInput != new Vector2())
        {
            directionalSpeed = new Vector3();

            directionalSpeed.x += moveInput.x;
            directionalSpeed.z += moveInput.y;

            directionalSpeed = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * directionalSpeed;
            directionalSpeed.Normalize();
            playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, Quaternion.LookRotation(directionalSpeed, playerBody.transform.up), 540f * Time.deltaTime);

            //Change directional force to be in line with the surface
            Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), Vector3.down, out groundAdherance, .2f, 1 << 9);
            Vector3 tempDir = new Vector3(1 - groundAdherance.normal.x, 1 - groundAdherance.normal.y, 1 - groundAdherance.normal.z);
            directionalSpeed = new Vector3(directionalSpeed.x * tempDir.x, directionalSpeed.y * tempDir.y, directionalSpeed.z * tempDir.z);

            //if (playerBody.velocity.magnitude < player.totalStats.MoveSpeed && GroundCheck())
            if(grounded)
                playerBody.AddForce(directionalSpeed * player.totalStats.MoveSpeed, ForceMode.Acceleration);
            else
                playerBody.AddForce(directionalSpeed * player.totalStats.MoveSpeed * .1f, ForceMode.Acceleration);

            //if (GroundCheck() && player.moveAbilityTimer > disregardGroundTime)
            //    playerBody.velocity = UtilityService.LimitVector3XZ(playerBody.velocity, player.totalStats.MoveSpeed);
        }

        //The .04f and time since grounded make it so the player doesn't slow down right when colliding with the ground. Bunny hopping felt terrible
        if (timeSinceGrounded > .04f && player.moveAbilityTimer > disregardGroundTime)
        {
            velocity = playerBody.velocity;
            velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, .25f);
            velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, .25f);
            playerBody.velocity = velocity;
        }

        if(!grounded)
        {
            velocity = playerBody.velocity;
            velocity.x = velocity.x * .998f;
            velocity.z = velocity.z * .998f;
            playerBody.velocity = velocity;
        }

        if (grounded && (timeSinceLastJump > disregardGroundTime || player.moveAbilityTimer > disregardGroundTime))
        {
            if (Physics.Raycast(player.transform.position + new Vector3(0, .1f, 0), Vector3.down, out groundAdherance, .2f, 1 << 9))
                playerBody.position = Vector3.Slerp(playerBody.position, groundAdherance.point, 1);// I feel like this shouldn't work but, whatever
        }
    }
}