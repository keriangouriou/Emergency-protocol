using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject characterPrefab;
    private Vector3 characterSpawnPosition;
    public GameObject character;
    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    private ScreenCenterMovement screenCenterMovement;
    private GameObject deathScreen;

    private void Awake()
    {
        character = GameObject.Find("Character");
        GetCharacterReferences();
        characterSpawnPosition = character.transform.position;
        screenCenterMovement = GameObject.Find("ScreenCenter").GetComponent <ScreenCenterMovement>();
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
    }
    public void Lose()
    {
        TurnOff();
        deathScreen.SetActive(true);
    }
    public void Restart()
    {
        Destroy(character);
        character = Instantiate(characterPrefab,characterSpawnPosition, Quaternion.identity);
        character.name = "Character";
        GetCharacterReferences();
        deathScreen.SetActive(false);
    }
    private void GetCharacterReferences()
    {
        playerControllerFP = character.GetComponent<PlayerControllerFP>();
        playerControllerSide = character.GetComponent<PlayerControllerSide>();
    }
    private void TurnOff()
    {
        playerControllerFP.enabled = false;
        playerControllerSide.enabled = false;
        screenCenterMovement.enabled = false;
    }
}
