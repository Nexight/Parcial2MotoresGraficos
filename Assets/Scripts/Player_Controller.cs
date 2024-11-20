using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player_Controller : MonoBehaviour
{

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float dashDistance = 5f;
    public float dashCooldown = 1f;
    public float dashDuration = 0.2f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    private Vector3 dashDirection;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;

    private bool canMove = true;
    private bool isDashing = false;
    private bool dashEnabled = false;

    void Start()
    {
        characterController = GetComponent <CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove&&!MenuPausa.GameIsPause)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if(isDashing)
        {
            Dash();
            return;
        }

        if(Input.GetKeyDown(KeyCode.E)&& dashEnabled && cooldownTimer <= 0)
        {
            StartDash();
        }

    }
    public void DashEnabler()
    {
        dashEnabled = true;
    }
    void StartDash()
    {
        isDashing = true;
        dashDirection = transform.forward; //dash hacia adelante
        dashTimer = dashDuration;
        cooldownTimer = dashCooldown;
    }

    void Dash()
    {
        float dashSpeed = dashDistance / dashDuration;
        characterController.Move(dashDirection * dashSpeed * Time.deltaTime);

        dashTimer -= Time.deltaTime;
        if(dashTimer<=0)
        {
            isDashing = false;
        }
    }

}
