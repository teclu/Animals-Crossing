using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public Transform Target;
    public GameObject PedestrianPrefab, Paths;

    public void SpawnPedestrian()
    {
        GameObject newPedestrian = Instantiate(PedestrianPrefab, transform.parent);
        newPedestrian.GetComponent<Pedestrian>().Target = Target;
        newPedestrian.transform.SetParent(Paths.transform);
        newPedestrian.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        newPedestrian.transform.position = gameObject.transform.position;
    }
}
