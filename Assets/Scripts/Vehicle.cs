using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    public Road PreviousRoad, CurrentRoad;

    private float speed = 5.0f;

    private void Start()
    {
        if (PreviousRoad == null && CurrentRoad != null)
        {
            PreviousRoad = CurrentRoad;
        }
    }

    private void Update()
    {
        if (CurrentRoad == null)
        {
            Image image = GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 1.0f * Time.deltaTime);
            if (image.color.a == 0.0f)
            {
                GameObject.Destroy(this.gameObject);
            }
            return;
        }

        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CurrentRoad.Node.position, step);
        if (Vector3.Distance(transform.position, CurrentRoad.Node.position) < 0.001f)
        {
            Road tempRoad = CurrentRoad;
            CurrentRoad = (PreviousRoad == CurrentRoad.RoadA) ? CurrentRoad.RoadB : CurrentRoad.RoadA;
            PreviousRoad = tempRoad;
        }
    }
}
