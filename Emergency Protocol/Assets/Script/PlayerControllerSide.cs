using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSide : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 moveInput;
    private float speed = 5f;
    private float screenSpeed = 3f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void HandleMovement()
    {
        Vector3 move = transform.forward * moveInput.x + transform.up * moveInput.y;
        
        Vector3 velocity = move * speed + transform.forward * screenSpeed;

        controller.Move(velocity * Time.deltaTime);
    }
}
