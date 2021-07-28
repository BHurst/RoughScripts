using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeldAbility : MonoBehaviour
{
    public Ability heldAbility;
    public RuneSlotImage abilityIcon;

    void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }
}