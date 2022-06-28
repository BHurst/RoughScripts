using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldObjectTooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI shorthandText;
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI tertiaryText;
    public RectTransform rectTransform;

    public GameObject topHalf;
    public GameObject bottomHalf;

    public void SetText(string headerContent, string shorthandContent, string bodyContent, string tertiaryContent)
    {
        if (!string.IsNullOrEmpty(headerContent))
        {
            headerText.gameObject.SetActive(true);
            headerText.SetText(headerContent);
        }
        else
        {
            headerText.SetText("");
            headerText.gameObject.SetActive(false);
        }

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

        if (!string.IsNullOrEmpty(bodyContent))
        {
            bodyText.gameObject.SetActive(true);
            bodyText.SetText(bodyContent);
        }
        else
        {
            bodyText.SetText("");
            bodyText.gameObject.SetActive(false);
        }

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

        if (string.IsNullOrEmpty(headerContent) && string.IsNullOrEmpty(shorthandContent))
            topHalf.SetActive(false);
        else
            topHalf.SetActive(true);

        if (string.IsNullOrEmpty(bodyContent) && string.IsNullOrEmpty(tertiaryContent))
            bottomHalf.SetActive(false);
        else
            bottomHalf.SetActive(true);
    }
}