using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform Node;
    public RoadType Type;
}

public enum RoadType
{
    Straight,
    Curved,
    Merge
}