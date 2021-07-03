using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObjects/Equipment")]
public class EquipmentSO : Item, IEquippable
{
    [field: SerializeField]
    public ScriptableObject fitsInSlot { get; set; }
    [field: SerializeField]
    public List<ModifierGroup> mods { get; set; } = new List<ModifierGroup>();
}