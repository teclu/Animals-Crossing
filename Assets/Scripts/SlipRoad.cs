using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlipRoad : Road
{
    public Road RoadA, RoadB1, RoadB2;
    public bool ToggleRotate;
    public GameObject ToggleSprite, RoadSprite;
    public Sprite[] RoadSprites;

    private void Start()
    {
        Type = RoadType.Slip;
        if (ToggleRotate)
        {
            RoadSprite.GetComponent<Image>().sprite = RoadSprites[0];
            Node.transform.Rotate(Vector3.forward, (ToggleRotate) ? 90.0f : -90.0f);
        }
    }

    public void OnClick()
    {
        ToggleRotate = !ToggleRotate;
        RoadSprite.GetComponent<Image>().sprite = RoadSprites[(ToggleRotate) ? 1 : 0];
        RoadSprite.transform.Rotate(Vector3.forward, (ToggleRotate) ? 90.0f : -90.0f);
        Node.transform.Rotate(Vector3.forward, (ToggleRotate) ? 90.0f : -90.0f);
    }
}
