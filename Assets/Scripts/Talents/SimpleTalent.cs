using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTalent : BaseTalent
{
    public int itemLevel;
    public int quality = 0;
    public List<ModifierGroup> modifiers = new List<ModifierGroup>();
}