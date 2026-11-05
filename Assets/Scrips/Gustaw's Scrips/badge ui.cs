
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMoveUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Vector2 targetPosition;

    public float moveAmount = 15f;
    public float speed = 8f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();// Get the RectTransform component of the UI element

        originalPosition = rectTransform.anchoredPosition;
        targetPosition = originalPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPosition = originalPosition + Vector2.left * moveAmount;// Move the UI element to the left when the pointer enters
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPosition = originalPosition;
    }

    void Update()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);// Smoothly move the UI element towards the target position
    }
}
