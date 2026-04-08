using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    public Transform screenCenterTransform;
    private bool isFirstPerson = true;
    private Camera cameraFP;
    public Camera cameraSide;
    private ScreenCenterMovement screenMoveScript;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControllerFP = GetComponent<PlayerControllerFP>();
        playerControllerSide = GetComponent<PlayerControllerSide>();
        cameraFP = GetComponentInChildren<Camera>();
        screenCenterTransform = GameObject.Find("ScreenCenter").transform;
        screenMoveScript = screenCenterTransform.GetComponent<ScreenCenterMovement>();
    }

    // Update is called once per frame
    public void SwitchMode()
    {
        if (isFirstPerson == true)
        {
            playerInput.actions.FindActionMap("PlayerFPS").Disable();
            playerInput.actions.FindActionMap("PlayerSide").Enable();
            playerControllerFP.enabled = false;
            playerControllerSide.enabled = true;
            transform.rotation = Quaternion.identity;
            cameraFP.enabled = false;
            cameraSide.enabled = true;
            screenMoveScript.enabled = true;
            screenCenterTransform.position = transform.position;

            isFirstPerson = false;
        }
        else
        {
            playerInput.actions.FindActionMap("PlayerSide").Disable();
            playerInput.actions.FindActionMap("PlayerFPS").Enable();
            playerControllerSide.enabled = false;
            playerControllerFP.enabled = true;
            cameraSide.enabled = false;
            cameraFP.enabled = true;
            screenMoveScript.enabled = false;
            isFirstPerson = true;
        }
    }
}
