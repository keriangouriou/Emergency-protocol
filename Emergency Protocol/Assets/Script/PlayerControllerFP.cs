using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerFP : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraPivot;

    private CharacterController controller;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool jumpInput;
    public bool isJumping;
    private int jumpBoostFrame;
    public int jumpBoostLenght = 40;
    public float jumpBoostStrenght = 1.5f;

    private float yVelocity;
    private float xRotation = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //FirstPerson
        Jump();
        HandleMovement();
        HandleLook();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
        }
    }
    public void OnStopJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = false;
        }
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        if (jumpInput == false)
        {
            yVelocity += -20f * Time.deltaTime;
        }
        else
        {
            yVelocity += -10f * Time.deltaTime;
        }

        Vector3 velocity = move * speed;
        if(jumpBoostFrame>0)
        {
            velocity = velocity * (1f + jumpBoostStrenght - (jumpBoostStrenght - jumpBoostStrenght * 0.05f * jumpBoostFrame));
            jumpBoostFrame --;
        }
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Jump()
    {
        if (controller.isGrounded && jumpInput == true)
        {
            isJumping = true;
            jumpBoostFrame = jumpBoostLenght;
            yVelocity = 6f;
        }

        if(isJumping == true && yVelocity<0)
        {
            isJumping = false;
        }
    }
}
