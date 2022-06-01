using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanBeLate
{
    public bool Started { get; set; }
    public void StartCheck();
}