using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public Road RoadSpawn;
    public float Interval;
    public GameObject VehiclePrefab;
    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Interval;
    }

    private void Update()
    {
        if (PauseMenuManager.isGamePaused)
        {
            return;
        }

        if (nextSpawnTime <= 0)
        {
            GameObject newVehicle = Instantiate(VehiclePrefab, transform);
            newVehicle.transform.position = RoadSpawn.Node.position;
            nextSpawnTime = Interval;
        }
        else
        {
            nextSpawnTime -= Time.deltaTime;
        }
    }
}
