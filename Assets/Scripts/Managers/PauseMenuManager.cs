using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool isGamePaused;

    private void Start()
    {
        isGamePaused = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isGamePaused);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isGamePaused);
        }
    }

    public void OnClickRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickResumeGame()
    {
        TogglePause();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
