using System;
using UnityEngine;

public class PortalToSideScript : MonoBehaviour
{
    private Collider invisbleWall;
    private CharacterController characterController;

    private void Awake()
    {
        invisbleWall = GetComponentInChildren<GetCollider>().GetColliderInvisWall();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            characterController = col.GetComponent<CharacterController>();
            characterController.Move(new Vector3(-col.transform.position.x, -col.transform.position.y, 1.5f));
            invisbleWall.enabled = true;
            col.GetComponent<PlayerManager>().SwitchMode();
        }
    }
}
