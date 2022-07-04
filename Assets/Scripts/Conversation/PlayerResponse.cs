using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResponse
{
    public string actualResponse;
    public bool canBeRepeated;
    public bool hasBeenSaid = false;
    public PlayerResponseRequirement responseRequirement;
    public int redirection;
}