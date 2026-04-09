using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    private ScreenCenterMovement screenCenterMovement;

    private void Awake()
    {
        playerControllerFP = GameObject.Find("Character").GetComponent<PlayerControllerFP>();
        playerControllerSide = GameObject.Find("Character").GetComponent<PlayerControllerSide>();
        screenCenterMovement = GameObject.Find("ScreenCenter").GetComponent <ScreenCenterMovement>();
    }
    public void Lose()
    {
        Debug.Log("You lose");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TurnOff()
    {
        playerControllerFP.enabled = false;
        playerControllerSide.enabled = false;
        screenCenterMovement.enabled = false;
    }
}
