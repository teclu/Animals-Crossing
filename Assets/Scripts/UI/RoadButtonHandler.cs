using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoadButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite ButtonUp, ButtonDown;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        GetComponent<Image>().sprite = ButtonDown;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        GetComponent<Image>().sprite = ButtonUp;
    }
}
