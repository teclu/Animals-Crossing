using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioSource ButtonHoverSound, ButtonClickSound;
    private TextMeshProUGUI buttonText;

    private void Start()
    {
        ButtonHoverSound = Instantiate(ButtonHoverSound, transform.parent.parent);
        ButtonClickSound = Instantiate(ButtonClickSound, transform.parent.parent);
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.color = Color.yellow;
        }
    }

    private void OnEnable()
    {
        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.color = Color.yellow;
            }
        }
    }

    private void OnDisable()
    {
        if (buttonText != null)
        {
            buttonText.color = Color.yellow;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = Color.gray;
        }
        ButtonHoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = Color.yellow;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = Color.gray;
        }
        ButtonClickSound.Play();
    }
}
