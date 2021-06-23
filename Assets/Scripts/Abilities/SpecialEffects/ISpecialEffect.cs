using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public interface ISpecialEffect {

    string specialEffectName { get; set; }
    int specialEffectID { get; set; }

    void Effect(Guid target);
}