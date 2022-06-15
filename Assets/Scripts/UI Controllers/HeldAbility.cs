using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeldAbility : MonoBehaviour
{
    public RootAbility ability;
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;
    public CanvasGroup canv;

    void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void SetImage(RootAbility ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.schoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.castModeRune.runeImageLocation);
        if (ability is BasicAbility)
            formImage.sprite = Resources.Load<Sprite>(((BasicAbility)ability).formRune.runeImageLocation);
        canv.alpha = 1;
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
        canv.alpha = 0;
    }
}