using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    //public GameObject destination;

    public Transform target;
    public float smoothTime = 3f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (Vector3.Distance(targetPosition, transform.position) <= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
