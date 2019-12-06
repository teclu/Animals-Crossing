using UnityEngine;

public class MergeRoad : Road
{
    public Road RoadA1, RoadA2, RoadB;
    
    private void Start()
    {
        Type = RoadType.Merge;
    }
}
