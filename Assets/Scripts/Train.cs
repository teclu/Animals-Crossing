using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    public Track PreviousTrack, CurrentTrack;

    private float speed = 5.0f;

    private void Start()
    {
        if (PreviousTrack == null && CurrentTrack != null)
        {
            PreviousTrack = CurrentTrack;
        }
    }

    private void Update()
    {
        if (CurrentTrack == null)
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
        transform.position = Vector3.MoveTowards(transform.position, CurrentTrack.Node.position, step);
        if (Vector3.Distance(transform.position, CurrentTrack.Node.position) < 0.001f)
        {
            Track tempTrack = CurrentTrack;
            CurrentTrack = (PreviousTrack == CurrentTrack.TrackA) ? CurrentTrack.TrackB : CurrentTrack.TrackA;
            PreviousTrack = tempTrack;
        }
    }
}
