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
        if (CurrentRoad == null)
        {
            CurrentRoad = transform.parent.gameObject.GetComponent<VehicleSpawner>().RoadSpawn;
        }
        transform.position = CurrentRoad.transform.position;
    }

    private void Update()
    {
        if (CurrentRoad == null)
        {
            Destroy(this.gameObject);
            return;
        }

        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CurrentRoad.Node.position, step);
        Quaternion rotateTo = (PreviousRoad == null) ? CurrentRoad.Node.rotation : PreviousRoad.Node.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, 512.0f * Time.deltaTime);
        if (Vector3.Distance(transform.position, CurrentRoad.Node.position) < 0.001f)
        {
            Road tempRoad = CurrentRoad;
            if (CurrentRoad.Type == RoadType.Straight)
            {
                StraightRoad straightRoad = (StraightRoad) CurrentRoad;
                CurrentRoad = (PreviousRoad == straightRoad.RoadA) ? straightRoad.RoadB : straightRoad.RoadA;
            }
            else if (CurrentRoad.Type == RoadType.Curved)
            {
                CurvedRoad curvedRoad = (CurvedRoad) CurrentRoad;
                if (PreviousRoad == curvedRoad.RoadB1 || PreviousRoad == curvedRoad.RoadB2)
                {
                    CurrentRoad = curvedRoad.RoadA;
                }
                else if (curvedRoad.IsToggable)
                {
                    CurrentRoad = (curvedRoad.ToggleRotate) ? curvedRoad.RoadB1 : curvedRoad.RoadB2;
                }
                else
                {
                    CurrentRoad = (PreviousRoad == curvedRoad.RoadA) ? ((curvedRoad.RoadB1 != null) ? curvedRoad.RoadB1 : curvedRoad.RoadB2) : curvedRoad.RoadA;
                }
            }
            else if (CurrentRoad.Type == RoadType.Merge)
            {
                MergeRoad mergeRoad = (MergeRoad)CurrentRoad;
                CurrentRoad = (PreviousRoad == mergeRoad.RoadA1 || PreviousRoad == mergeRoad.RoadA2) ? mergeRoad.RoadB : mergeRoad.RoadA1;
            }
            PreviousRoad = tempRoad;
        }
    }
}
