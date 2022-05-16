using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI shorthandText;
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI tertiaryText;
    public RectTransform rectTransform;

    public void SetText(string headerContent, string shorthandContent, string bodyContent, string tertiaryContent)
    {
        headerText.SetText(headerContent);

        if(!string.IsNullOrEmpty(shorthandContent))
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

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}