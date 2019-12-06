using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedRoad : Road
{
    public Road RoadA, RoadB1, RoadB2;
    public bool IsToggable, ToggleRotate;
    
    private void Start()
    {
        Type = RoadType.Curved;
    }
}
