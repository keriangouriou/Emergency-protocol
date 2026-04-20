using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPrefab;
    public Vector3 characterSpawnPosition;
    public GameObject character;

    private PlayerControllerFP playerControllerFP;
    private PlayerControllerSide playerControllerSide;
    private ScreenCenterMovement screenCenterMovement;
    private GameObject deathScreen;
    private GameObject winScreen;
    private Image blackScreen;
    private void Awake()
    {
        character = GameObject.Find("Character");
        GetCharacterReferences();
        characterSpawnPosition = character.transform.position;
        screenCenterMovement = GameObject.Find("ScreenCenter").GetComponent <ScreenCenterMovement>();
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
        winScreen = GameObject.Find("WinScreen");
        winScreen.SetActive(false);
        blackScreen = GameObject.Find("BlackScreenImage").GetComponent<Image>();
        StartCoroutine(BlackScreenFadeOut());
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
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Portal"))
        {
            go.GetComponent<DisableInvisibleWall>().DisableWall();
        }
        deathScreen.SetActive(false);
    }

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
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

    //UI Coroutine
    private IEnumerator BlackScreenFadeIn()
    {
        blackScreen.enabled = true;
        for (int i = 10; i >= 0; i--)
        {
            blackScreen.color = new Color(0, 0, 0, 1 - (0.1f * i));
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator BlackScreenFadeOut()
    {
        for (int i = 0; i <= 10; i++)
        {
            blackScreen.color = new Color(0, 0, 0, 1 - (0.1f * i));
            yield return new WaitForSeconds(0.05f);
        }
        blackScreen.enabled = false;
    }

    public IEnumerator WinEnd()
    {
        StartCoroutine(BlackScreenFadeIn());
        yield return new WaitForSeconds(0.5f);
        TurnOff();
        winScreen.SetActive(true);
        StartCoroutine(BlackScreenFadeOut());
    }
    public IEnumerator ReloadCoroutine()
    {
        StartCoroutine(BlackScreenFadeIn());
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
