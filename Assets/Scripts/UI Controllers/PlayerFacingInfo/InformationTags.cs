using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTags
{
    public static string GetTagInfo(InfoTag tag)
    {
        switch (tag)
        {
            case InfoTag.None:
                return "";
            case InfoTag.AddPercent:
                return "All Increases are additive with eachother";
            case InfoTag.MultiplyPercent:
                return "All Increases are multiplicative with eachother";
            default:
                return "God help you";
        }
    }

    public enum InfoTag
    {
        None,
        AddPercent,
        MultiplyPercent
    }
}