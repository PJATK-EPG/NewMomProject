using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPController))]
[RequireComponent(typeof(CharacterController))]
public class FPInputHandler : StateInputHandler
{
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public override void HandleInput()
    {
        float movementDirectionY = CountMovement();
        CountGravity(movementDirectionY);
        characterController.Move(moveDirection * Time.deltaTime);
        MakeRotation();
    }
    private float CountMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = isRunning ? runningSpeed : walkingSpeed * Input.GetAxis("Vertical");
        float curSpeedY = isRunning ? runningSpeed : walkingSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        return movementDirectionY;
    }

    private void CountGravity(float movementDirectionY)
    {
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }
    private void MakeRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
