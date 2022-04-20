using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleItemPickupPanel : MonoBehaviour
{
    public TextMeshProUGUI tmproText;
    public Image image;
    public float popupDuration = 1;

    void Start()
    {
        tmproText.SetText("Invalid Item");
        //image.sprite = Resources.Load<Sprite>("Prefabs/Images/ItemPlaceholder");
        popupDuration = 2.5f;
    }

    void Update()
    {
        popupDuration -= Time.deltaTime;

        if (popupDuration <= 1f)
        {
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, popupDuration);
            if(popupDuration <= 0)
                Destroy(gameObject);
        }

    }
}