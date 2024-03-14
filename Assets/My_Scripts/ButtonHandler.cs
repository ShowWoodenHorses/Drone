using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform Player;
    public bool isTap = false;

    public float speedRotate;
    public float speedUpDown;

    public List<ButtonHandler> buttons = new List<ButtonHandler>();

    void Start()
    {
        foreach (ButtonHandler button in buttons)
        {
            button.speedRotate = this.speedRotate;
            button.speedUpDown = this.speedUpDown;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTap = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTap = false;
    }
}
