using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : MonoBehaviour
{

    public Transform playerTransform;
    public Rigidbody playerBody;
    public PlayerCharacterUnit player;
    public Collider playerCollider;
    public GameObject closestItem;
    float right;
    float left;
    float forward;
    float backward;
    bool jump;
    bool use;
    public static bool faceForward = false;
    public static float facingAngle = 0f;
    public Vector3 velocity;
    public float drag = 45f;
    public float maxSpeed = 0f;
    Vector3 horizontal;
    Vector3 vertical;
    Vector3 finalVelocity;
    int jumpCount = 1;
    public Transform cameraFocus;
    float damperx = 0;
    float dampery = 0;

    void SetMainUnit(Transform unit)
    {
        playerTransform = unit;
        playerBody = unit.GetComponent<Rigidbody>();
        player = unit.GetComponent<PlayerCharacterUnit>();
        playerCollider = unit.GetComponent<Collider>();
    }

    bool GroundCheck()
    {
        float xBound = playerCollider.bounds.size.x / 2;
        float yBound = playerCollider.bounds.size.y / 2;
        float zBound = playerCollider.bounds.size.z / 2;

        RaycastHit hitNW;
        RaycastHit hitNE;
        RaycastHit hitSW;
        RaycastHit hitSE;
        Physics.Raycast(playerTransform.position + new Vector3(-xBound, player.waistHight, zBound), Vector3.down, out hitNW, (player.waistHight) + 0.2f);
        Physics.Raycast(playerTransform.position + new Vector3(xBound, player.waistHight, zBound), Vector3.down, out hitNE, (player.waistHight) + 0.2f);
        Physics.Raycast(playerTransform.position + new Vector3(-xBound, player.waistHight, -zBound), Vector3.down, out hitSW, (player.waistHight) + 0.2f);
        Physics.Raycast(playerTransform.position + new Vector3(xBound, player.waistHight, -zBound), Vector3.down, out hitSE, (player.waistHight) + 0.2f);
        if (hitNW.collider != null || hitNE.collider != null || hitSW.collider != null || hitSE.collider != null)
            return true;
        else
            return false;
    }

    void Update()
    {
        right = Input.GetAxis("Right");
        left = Input.GetAxis("Left");
        forward = Input.GetAxis("Up");
        backward = Input.GetAxis("Down");

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;

        if (Input.GetKeyDown(KeyCode.E))
            use = true;
    }

    void FixedUpdate()
    {

        if (player.actionCooldown <= 0)
        {
            //playerBody.rotation = Camera.main.transform.rotation;

            Vector3 directionalSpeed = new Vector3();

            if (right == 1f)
                directionalSpeed.x += 1f;
            if (left == 1f)
                directionalSpeed.x -= 1f;

            if (forward == 1f)
                directionalSpeed.z += 1f;
            if (backward == 1f)
                directionalSpeed.z -= 1f;

            directionalSpeed.Normalize();
            if (!GroundCheck())
                directionalSpeed *= .3f;

            if (right == 0 && left == 0 && forward == 0 && backward == 0 && GroundCheck())
            {
                velocity = playerBody.velocity;
                velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, .15f);
                velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, .15f);
                playerBody.velocity = velocity;
            }

            playerBody.AddRelativeForce(directionalSpeed * player.totalStats.MoveSpeed * Time.deltaTime);

            maxSpeed = player.totalStats.MoveSpeed * 2;

            if (playerBody.velocity.magnitude > maxSpeed && GroundCheck())
            {
                velocity = playerBody.velocity;
                velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, .1f);
                velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, .1f);
                playerBody.velocity = velocity;
            }

            if (jump && GroundCheck())
            {
                playerBody.AddForce(new Vector3(0, player.totalStats.JumpHeight, 0));
                jump = false;
            }
            else
                jump = false;
        }
        else
        {
            if (GroundCheck())
            {
                velocity = playerBody.velocity;
                velocity.x = Mathf.SmoothDamp(velocity.x, 0, ref damperx, .15f);
                velocity.z = Mathf.SmoothDamp(velocity.z, 0, ref dampery, .15f);
                playerBody.velocity = velocity;
            }
        }

        closestItem = UtilityService.ClosestObject(playerTransform.position, 2, 1 << 10);

        if (use && closestItem != null)
        {
            player.charInventory.PickUp(closestItem.GetComponent<WorldItem>());
            closestItem = null;
        }

        closestItem = null;
        use = false;

        //cameraFocus.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0); //Attempted to keep the shoulder consistent with orbiting. Thing spazzes out.
    }
}