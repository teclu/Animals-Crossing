using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedRoad : Road
{
    public Road RoadA, RoadB1, RoadB2;
    public bool IsToggable, ToggleRotate;
    public GameObject ToggleSprite;
    public GameObject RoadSprite;
    
    private void Start()
    {
        Type = RoadType.Curved;
        ToggleSprite.SetActive(IsToggable);
    }

    public void OnClick()
    {
        Debug.Log("YO");
        if (IsToggable)
        {
            ToggleRotate = !ToggleRotate;
            RoadSprite.transform.Rotate(Vector3.forward, (ToggleRotate) ? -90.0f : 90.0f);
        }
    }
}
