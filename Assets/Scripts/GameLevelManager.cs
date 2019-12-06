using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    public TextMeshProUGUI DeathCount;

    private int deathCount = 0;

    private void Start()
    {
        DeathCount.text = "Deaths: 0";
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
}
