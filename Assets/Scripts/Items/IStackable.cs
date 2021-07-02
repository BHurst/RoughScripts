using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackable
{
    public int maxStackSize { get; set; }
    public int currentStackSize { get; set; }
}