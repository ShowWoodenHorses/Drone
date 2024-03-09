using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform Player;
    public bool isTap = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isTap = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTap = false;
    }
}
