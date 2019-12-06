using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    public TextMeshProUGUI DeathCount;
    public TextMeshProUGUI TimerCountDown;

    public float TimerCountDownValue;
    private int deathCount = 0;

    private void Start()
    {
        DeathCount.text = "Deaths: 0";
        TimerCountDown.text = "Time Left: " + (int) TimerCountDownValue;
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

    private void Update()
    {
        if (PauseMenuManager.isGamePaused)
        {
            return;
        }

        if (TimerCountDownValue > 0)
        {
            TimerCountDownValue -= Time.deltaTime;
            
            if (TimerCountDownValue <= 0.0f)
            {
                TimerCountDownValue = 0.0f;
            }
        }
        TimerCountDown.text = "Time Left: " + (int) TimerCountDownValue;
    }
}
