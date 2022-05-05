using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeldAbility : MonoBehaviour
{
    public Ability ability;
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;

    void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void SetImage(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.runeImageLocation);
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.runeImageLocation);
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
    }
}