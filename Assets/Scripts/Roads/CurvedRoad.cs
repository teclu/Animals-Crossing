using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedRoad : Road
{
    public Road RoadA, RoadB1, RoadB2;
    public bool IsToggable, ToggleRotate;
    public GameObject ToggleSprite, RoadSprite;
    
    private void Start()
    {
        Type = RoadType.Curved;
        ToggleSprite.SetActive(IsToggable);
        if (ToggleRotate)
        {
            RoadSprite.transform.Rotate(Vector3.forward, (ToggleRotate) ? -90.0f : 90.0f);
            Node.transform.Rotate(Vector3.forward, (ToggleRotate) ? -180.0f : 180.0f);
        }
    }

    public void OnClick()
    {
        if (IsToggable)
        {
            ToggleRotate = !ToggleRotate;
            RoadSprite.transform.Rotate(Vector3.forward, (ToggleRotate) ? -90.0f : 90.0f);
            Node.transform.Rotate(Vector3.forward, (ToggleRotate) ? -180.0f : 180.0f);
        }
    }
}
