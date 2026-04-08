using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSide : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 moveInput;
    private float speed = 10f;
    private float screenSpeed;
    private Transform screenCenterTransform;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        screenSpeed = GameObject.Find("ScreenCenter").GetComponent<ScreenCenterMovement>().screenSpeed;
        screenCenterTransform = GameObject.Find("ScreenCenter").transform;
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
