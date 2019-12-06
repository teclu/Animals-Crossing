using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestrianFart : MonoBehaviour
{
    public Sprite[] Farts;
    public AudioSource FartAudioSource;

    private void Start()
    {
        GetComponent<Image>().sprite = Farts[new System.Random().Next(0, Farts.Length - 1)];
        FartAudioSource = Instantiate(FartAudioSource, transform);
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
