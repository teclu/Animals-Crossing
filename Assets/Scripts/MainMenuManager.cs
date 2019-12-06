using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject TitleScreen, InstructionsScreen, CreditsScreen;

    private void Start()
    {
        TitleScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }
    
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnClickInstructions()
    {
        TitleScreen.SetActive(false);
        InstructionsScreen.SetActive(true);
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
        InstructionsScreen.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
