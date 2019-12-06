using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestrianFart : MonoBehaviour
{
    public Sprite[] farts;

    private void Start()
    {
        GetComponent<Image>().sprite = farts[new System.Random().Next(0, farts.Length - 1)];
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * new System.Random().Next(-120, 120));
        FadeOut();
    }

    private void FadeOut()
    {
        Image image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * 1.0f);
        if (image.color.a < 0.05f)
        {
            Destroy(this.gameObject);
        }
    }
}
