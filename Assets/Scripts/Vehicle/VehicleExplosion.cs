using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleExplosion : MonoBehaviour
{
    public AudioSource ExplosionAudioSource;

    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        ExplosionAudioSource = Instantiate(ExplosionAudioSource, transform);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * new System.Random().Next(-120, 120));
        if (Vector3.Distance(Vector3.one, transform.localScale) > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 1.0f, transform.localScale.y + Time.deltaTime * 1.0f, transform.localScale.z + Time.deltaTime * 1.0f);
        }
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
