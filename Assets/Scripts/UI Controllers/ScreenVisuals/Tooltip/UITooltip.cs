using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UITooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI shorthandText;
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI tertiaryText;
    public RectTransform rectTransform;

    float pivotX = 0;
    float offsetX = 0;
    float pivotY = 0;
    float offsetY = 0;

    public void SetText(string headerContent, string shorthandContent, string bodyContent, string tertiaryContent)
    {
        headerText.SetText(headerContent);

        if (!string.IsNullOrEmpty(shorthandContent))
        {
            shorthandText.gameObject.SetActive(true);
            shorthandText.SetText(shorthandContent);
        }
        else
        {
            shorthandText.SetText("");
            shorthandText.gameObject.SetActive(false);
        }

        bodyText.SetText(bodyContent);

        if (!string.IsNullOrEmpty(tertiaryContent))
        {
            tertiaryText.gameObject.SetActive(true);
            tertiaryText.SetText(tertiaryContent);
        }
        else
        {
            tertiaryText.SetText("");
            tertiaryText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Vector2 position = Mouse.current.position.ReadValue();

        if (position.x / Screen.width > .5f)
        {
            pivotX = 1;
            offsetX = -10;
        }
        else
        {
            pivotX = 0;
            offsetX = 10;
        }

        if (position.y / Screen.height > .5f)
        {
            pivotY = 1;
            offsetY = -10;
        }
        else
        {
            pivotY = 0;
            offsetY = 10;
        }

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position + new Vector2() { x = offsetX, y = offsetY };
    }
}