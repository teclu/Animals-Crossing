using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public Transform Target;
    public float Interval;
    private float nextSpawnTime;
    public GameObject PedestrianPrefab;

    private void Start()
    {
        nextSpawnTime = Interval;
    }

    private void Update()
    {
        if (nextSpawnTime <= 0)
        {
            GameObject newPedestrian = Instantiate(PedestrianPrefab, transform.parent);
            newPedestrian.GetComponent<PedestrianController>().Target = Target;
            newPedestrian.transform.SetParent(gameObject.transform.parent);
            newPedestrian.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            newPedestrian.transform.position = gameObject.transform.position;
            nextSpawnTime = Interval;
        }
        else
        {
            nextSpawnTime -= Time.deltaTime;
        }
    }
}
