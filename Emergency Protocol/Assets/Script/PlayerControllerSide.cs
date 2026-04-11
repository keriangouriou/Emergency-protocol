using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSide : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 moveInput;
    private float speed = 15f;
    private float screenSpeed;
    private float distanceZ;
    private float distanceZNoAbsolute;
    private float distanceY;
    private float distanceYNoAbsolute;
    private float LimitZ;
    private float LimitY;
    private float ClampZ = 12f;
    private float ClampY = 6.5f;
    public Transform screenCenterTransform;

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
        //Store inputs direction into a Vector 3
        Vector3 move = transform.forward * moveInput.x + transform.up * moveInput.y;

        //Clamp Z
        distanceZNoAbsolute = transform.position.z - screenCenterTransform.position.z;
        distanceZ = Math.Abs(distanceZNoAbsolute);
        LimitZ = ClampZ - distanceZ;
        if (LimitZ <= 0.2 && Math.Sign(move.z) == Math.Sign(distanceZNoAbsolute))
        {
            move.z = 0;
            Vector3 clampZ = transform.forward * (screenCenterTransform.position.z + ClampZ * Math.Sign(distanceZNoAbsolute) - transform.position.z);
            controller.Move(clampZ);
        }

        //Clamp Y
        distanceYNoAbsolute = transform.position.y - screenCenterTransform.position.y;
        distanceY = Math.Abs(distanceYNoAbsolute);
        LimitY = ClampY - distanceY;
        if (LimitY <= 0.2 && Math.Sign(move.y) == Math.Sign(distanceYNoAbsolute))
        {
            move.y = 0;
            Vector3 clampY = transform.up * (screenCenterTransform.position.y + ClampY * Math.Sign(distanceYNoAbsolute) - transform.position.y);
            controller.Move(clampY);
        }

        //Apply speed multiplayer and screenspeed then move
        Vector3 velocity = move * speed + transform.forward * screenSpeed;
        controller.Move(velocity * Time.deltaTime);
    }
}
