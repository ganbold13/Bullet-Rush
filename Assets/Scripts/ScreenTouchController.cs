using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _touchPosition;
    public Vector2 Direction {get; private set; }
    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = (Vector2)Vector3.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - _touchPosition; 
        Direction = delta.normalized;
    }
}