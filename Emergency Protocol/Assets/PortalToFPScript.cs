using UnityEngine;

public class PortalToFPScript : MonoBehaviour
{
    public Collider invisbleWall;
    private CharacterController characterController;

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            characterController = col.GetComponent<CharacterController>();
            characterController.Move(new Vector3(0, 0, 1));
            invisbleWall.enabled = true;
            col.GetComponent<PlayerManager>().SwitchMode();
        }
    }
}
