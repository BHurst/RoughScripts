using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanBeDamaged
{
    public bool isAlive { get; set; }

    public void InflictDamage(float value, bool overTime);

    public void InflictHealing(float value, bool overTime);
}