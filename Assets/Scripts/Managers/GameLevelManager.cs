using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    public TextMeshProUGUI DeathCount;
    public TextMeshProUGUI TimerCountDown;
    public GameObject NextLevelButton;

    public float TimerCountDownValue;
    public int NextLevelNumber = -1;
    private int deathCount = 0;

    private void Start()
    {
        DeathCount.text = "Deaths: 0";
        TimerCountDown.text = "Time Left: " + (int) TimerCountDownValue;
        NextLevelButton.SetActive(false);
    }

    private void OnEnable()
    {
        Events.instance.AddListener<DeathEvent>(IncrementDeathCount);
    }
 
    private void OnDisable()
    {
        Events.instance.RemoveListener<DeathEvent>(IncrementDeathCount);
    }

    public void IncrementDeathCount(DeathEvent e)
    {
        deathCount++;
        DeathCount.text = "Deaths: " + deathCount;
    }

    public void OnClickLoadNextLevel()
    {
        SceneManager.LoadScene("Level_" + NextLevelNumber);
    }

    private void Update()
    {
        if (PauseMenuManager.isGamePaused)
        {
            return;
        }

        if (TimerCountDownValue == 0.0f)
        {
            return;
        }

        if (TimerCountDownValue > 0)
        {
            TimerCountDownValue -= Time.deltaTime;
            
            if (TimerCountDownValue <= 0.0f)
            {
                TimerCountDownValue = 0.0f;
                if (NextLevelNumber > 0)
                {
                    NextLevelButton.SetActive(true);
                }
            }
        }
        TimerCountDown.text = "Time Left: " + (int) TimerCountDownValue;
    }
}
