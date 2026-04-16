using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private GameObject blackScreen;
    private Image blackScreenImage;
    private GameObject LoadingScreen;
    private void Awake()
    {
        blackScreen = GameObject.Find("BlackScreen");
        blackScreen.SetActive(false);
        blackScreenImage = blackScreen.GetComponent<Image>();
        LoadingScreen = GameObject.Find("LoadingScreen");
        LoadingScreen.SetActive(false);
    }
    public void ChangeToScene(string sceneName)
    {
        StartCoroutine(LoadingScreenThenChangeScene(sceneName));
    }

    IEnumerator LoadingScreenThenChangeScene(string sceneName)
    {
        //first Veil appear
        blackScreen.SetActive(true);
        for (int i = 10; i >= 0; i--)
        {
            blackScreenImage.color = new Color(0,0,0,1 - (0.1f * i));
            yield return new WaitForSeconds(0.05f);
        }
        
        LoadingScreen.SetActive(true);

        for (int i = 0; i <= 10; i++)
        {
            blackScreenImage.color = new Color(0, 0, 0, 1 - (0.1f * i));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        for (int i = 10; i >= 0; i--)
        {
            blackScreenImage.color = new Color(0, 0, 0, 1 - (0.1f * i));
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene(sceneName);
    }
    

}
