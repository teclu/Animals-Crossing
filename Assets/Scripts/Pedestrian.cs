using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestrian : MonoBehaviour
{
    //public GameObject destination;

    public Transform Target;
    public float SmoothTime = 12.0f;
    public Sprite[] avatars;
    private Vector3 velocity = Vector3.zero, targetPosition;
    private bool isDead;

    private void Start()
    {
        targetPosition = Target.position;
        isDead = false;
        GetComponent<Image>().sprite = avatars[new System.Random().Next(0, avatars.Length - 1)];
    }

    private void Update()
    {
        if (isDead)
        {
            Image image = GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * 1.0f);
            if (image.color.a == 0.0f)
            {
                Destroy(this.gameObject);
            }
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        if (Vector3.Distance(targetPosition, transform.position) <= 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle" && !isDead)
        {
            isDead = true;
            GetComponent<Image>().sprite = avatars[avatars.Length - 1];
        }
    }
}
