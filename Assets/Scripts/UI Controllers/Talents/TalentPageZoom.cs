using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TalentPageZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform content;
    Vector2 scrollInput;
    Vector2 pivot;
    float newScale;
    bool hovering;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    private void Update()
    {
        scrollInput = Mouse.current.scroll.ReadValue();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, Mouse.current.position.ReadValue(), Camera.main, out pivot);
        pivot = Rect.PointToNormalized(content.rect, pivot);
        newScale = content.localScale.x;
        if (scrollInput.y > 0 && hovering)
        {
            //content.pivot = pivot;
            newScale = Mathf.Clamp(newScale + .125f, .25f, 1f);
            content.localScale = new Vector3(newScale, newScale);
        }
        else if(scrollInput.y < 0 && hovering)
        {
            //content.pivot = pivot;
            newScale = Mathf.Clamp(newScale - .125f, .25f, 1f);
            content.localScale = new Vector3(newScale, newScale);
        }
    }
}