using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public Transform target;
    public float interval;
    private float next_spawn_time;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            GameObject new_pedestrian = Instantiate(prefab, transform.parent);
            new_pedestrian.GetComponent<PedestrianController>().target = target;
            new_pedestrian.transform.SetParent(gameObject.transform.parent);
            new_pedestrian.transform.localScale = new Vector3(1f, 1f, 1f);
            new_pedestrian.transform.position = gameObject.transform.position;
            next_spawn_time += interval;
        }
    }
}
