using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{
    public Image bar;
    public TextMeshProUGUI text;
    public PlayerCharacterUnit player;
    float castPercent = 0;
    float timeLeft = 0;

    private void Update()
    {
        if (player == null)
            player = PlayerCharacterUnit.player;

        if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast))
        {
            castPercent = player.currentCastingTime / player.totalStats.ReserveRecoveryTime_Default;
            timeLeft = (player.totalStats.ReserveRecoveryTime_Default / (1 + player.totalStats.Cast_Rate_AddPercent.value) / player.totalStats.Cast_Rate_MultiplyPercent.value) - (player.currentCastingTime / (1 + player.totalStats.Cast_Rate_AddPercent.value) / player.totalStats.Cast_Rate_MultiplyPercent.value);
            bar.fillAmount = castPercent;
            text.text = string.Format("{0:#.0}", timeLeft <= 0 ? "" : timeLeft);
            if ((castPercent >= 1 && player.abilityPreparingToCast.castModeRune.castModeRuneType != Rune.CastModeRuneTag.Charge) || (timeLeft <= 0 && player.abilityPreparingToCast.castModeRune.castModeRuneType != Rune.CastModeRuneTag.Charge))
            {
                bar.fillAmount = 0;
                text.text = "";
            }
        }
        else
        {
            bar.fillAmount = 0;
            text.text = "";
        }
    }
}