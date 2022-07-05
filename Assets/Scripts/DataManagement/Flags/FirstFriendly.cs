using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class FirstFriendly : BaseFlag
{
    public bool turnedInShale = false;
    public override bool CheckFlag()
    {
        return turnedInShale;
    }

    public static FieldInfo GetFlagName()
    {
        return typeof(FirstFriendly).GetField("turnedInShale");
    }
}