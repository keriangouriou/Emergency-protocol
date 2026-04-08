using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    public bool isFirstPerson = true;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControllerFP = GetComponent<PlayerControllerFP>();
        playerControllerSide = GetComponent<PlayerControllerSide>();
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
            isFirstPerson = false;
        }
        else
        {
            playerInput.actions.FindActionMap("PlayerSide").Disable();
            playerInput.actions.FindActionMap("PlayerFPS").Enable();
            playerControllerSide.enabled = false;
            playerControllerFP.enabled = true;

            isFirstPerson = true;
        }
    }
}
