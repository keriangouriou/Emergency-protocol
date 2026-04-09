using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    private ScreenCenterMovement screenCenterMovement;
    private GameObject deathScreen;

    private void Awake()
    {
        playerControllerFP = GameObject.Find("Character").GetComponent<PlayerControllerFP>();
        playerControllerSide = GameObject.Find("Character").GetComponent<PlayerControllerSide>();
        screenCenterMovement = GameObject.Find("ScreenCenter").GetComponent <ScreenCenterMovement>();
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
    }
    public void Lose()
    {
        Debug.Log("You lose");
        TurnOff();
        deathScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void TurnOff()
    {
        playerControllerFP.enabled = false;
        playerControllerSide.enabled = false;
        screenCenterMovement.enabled = false;
    }
}
