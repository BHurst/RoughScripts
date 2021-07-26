using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeldAbility : MonoBehaviour
{
    public Ability heldAbility;
    public Text abilityName;

    void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }
}