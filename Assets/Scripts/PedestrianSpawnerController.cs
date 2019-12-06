using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnerController : MonoBehaviour
{
    public PedestrianSpawner[] pedestrianSpawners;
    public float SwapSpawnerInterval;
    public float SpawnerInterval;

    private float nextSwapSpawnerInterval;
    private float nextSpawnerInterval;
    private int spawnerIndex;
    private System.Random rngesus;

    private void Start()
    {
        nextSwapSpawnerInterval = SwapSpawnerInterval;
        nextSpawnerInterval = SpawnerInterval;
        rngesus = new System.Random((int)DateTime.Now.Ticks + this.GetInstanceID());
        spawnerIndex = rngesus.Next(0, pedestrianSpawners.Length);
    }

    private void Update()
    {
        if (nextSwapSpawnerInterval <= 0.0f)
        {
            spawnerIndex = rngesus.Next(0, pedestrianSpawners.Length);
            nextSwapSpawnerInterval = SwapSpawnerInterval;
        }
        if (nextSpawnerInterval <= 0.0f)
        {
            pedestrianSpawners[spawnerIndex].SpawnPedestrian();
            nextSpawnerInterval = SpawnerInterval;
        }
        nextSwapSpawnerInterval -= Time.deltaTime;
        nextSpawnerInterval -= Time.deltaTime;
    }
}
