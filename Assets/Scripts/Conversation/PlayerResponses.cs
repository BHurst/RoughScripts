using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResponses {
    public string actualResponse;
    public bool canBeRepeated;
    public bool hasBeenSaid = false;
    public string worldStateRequirement = "None";
    public string itemRequirement = "None";
    public string statRequirement = "None";
    public int redirection;
}