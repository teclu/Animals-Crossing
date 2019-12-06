using UnityEngine;

public class StraightRoad : Road
{
    public Road RoadA, RoadB;
    
    private void Start()
    {
        Type = RoadType.Straight;
    }
}
