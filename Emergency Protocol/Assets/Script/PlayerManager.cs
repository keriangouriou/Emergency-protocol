using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    private MeshRenderer playerRenderer;
    private Transform screenCenterTransform;
    private bool isFirstPerson = true;
    private Camera cameraFP;
    private Camera cameraSide;
    private ScreenCenterMovement screenMoveScript;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControllerFP = GetComponent<PlayerControllerFP>();
        playerControllerSide = GetComponent<PlayerControllerSide>();
        cameraFP = GetComponentInChildren<Camera>();
        screenCenterTransform = GameObject.Find("ScreenCenter").transform;
        screenMoveScript = screenCenterTransform.GetComponent<ScreenCenterMovement>();
        playerRenderer = GetComponentInChildren<MeshRenderer>();
        playerRenderer.enabled = false;
        cameraSide = GameObject.Find("CameraSide").GetComponent<Camera>();
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
            playerRenderer.enabled = true;
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
            playerRenderer.enabled = false;
            isFirstPerson = true;
        }
    }
}
