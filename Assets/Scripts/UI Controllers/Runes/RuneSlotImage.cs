using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneSlotImage : MonoBehaviour
{
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;

    public void SetImage(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.RuneImageLocation());
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.RuneImageLocation());
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.RuneImageLocation());
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
    }
}