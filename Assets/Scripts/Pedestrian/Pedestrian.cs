using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestrian : MonoBehaviour
{
    //public GameObject destination;

    public Transform Target;
    public float FartInterval;
    public Sprite[] avatars;
    public GameObject fartPrefab;
    private Vector3 velocity = Vector3.zero, startPosition, targetPosition;
    private bool isDead;
    private float SmoothTime = 3.5f, fartInterval;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = Target.position;
        isDead = false;
        fartInterval = 0.0f;
        Image image = GetComponent<Image>();
        image.sprite = avatars[new System.Random().Next(0, avatars.Length - 1)];
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
    }

    private void Update()
    {
        if (PauseMenuManager.isGamePaused)
        {
            return;
        }

        if (isDead)
        {
            FadeOut();
            transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * new System.Random().Next(-960, 960));
            if (fartInterval <= 0)
            {
                GameObject fart = Instantiate(fartPrefab, transform);
                fart.transform.SetParent(transform.parent);
                fartInterval = FartInterval;
            }
            else
            {
                fartInterval -= Time.deltaTime;
            }
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        if (Vector3.Distance(targetPosition, transform.position) <= 1.0f)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
    }

    private void FadeIn()
    {
        Image image = GetComponent<Image>();
        if (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime * 2.0f);
        }
    }

    private void FadeOut()
    {
        Image image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * 2.0f);
        if (image.color.a < 0.05f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle" && !isDead)
        {
            isDead = true;
            Events.instance.Raise(new DeathEvent {Type = DeathEvent.DeathType.Pedestrian});
        }
    }
}
