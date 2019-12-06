using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject TitleScreen, CreditsScreen;

    private void Start()
    {
        TitleScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }
    
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnClickCredits()
    {
        TitleScreen.SetActive(false);
        CreditsScreen.SetActive(true);
    }

    public void OnClickBackToTitleScreen()
    {
        TitleScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
