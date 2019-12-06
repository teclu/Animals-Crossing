using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnerController : MonoBehaviour
{
    public PedestrianSpawner[] pedestrianSpawners;
    public float Interval;

    private float nextSpawnTime;
    private System.Random rngesus;

    private void Start()
    {
        nextSpawnTime = Interval;
        rngesus = new System.Random();
    }

    private void Update()
    {
        if (nextSpawnTime <= 0.0f)
        {
            int index = rngesus.Next(0, pedestrianSpawners.Length);
            pedestrianSpawners[index].SpawnPedestrian();
            nextSpawnTime = Interval;
        }
        else
        {
            nextSpawnTime -= Time.deltaTime;
        }
    }
}
