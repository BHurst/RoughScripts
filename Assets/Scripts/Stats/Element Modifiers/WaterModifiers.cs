using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterModifiers
{
    List<ModifierGroup> Water_Modifiers = new List<ModifierGroup>()
    {
        //Offensive
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 01, RangeHigh = 03, DropWeight = 1000,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 04, RangeHigh = 07, DropWeight = 900,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 08, RangeHigh = 12, DropWeight = 800,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 13, RangeHigh = 18, DropWeight = 700,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 19, RangeHigh = 25, DropWeight = 600,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 26, RangeHigh = 33, DropWeight = 500,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 34, RangeHigh = 42, DropWeight = 400,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 43, RangeHigh = 52, DropWeight = 300,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 53, RangeHigh = 63, DropWeight = 200,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 64, RangeHigh = 75, DropWeight = 100,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .09f, DropWeight = 1000,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .10f, RangeHigh = .14f, DropWeight = 900,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .15f, RangeHigh = .19f, DropWeight = 800,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .20f, RangeHigh = .24f, DropWeight = 700,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .29f, DropWeight = 600,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .30f, RangeHigh = .34f, DropWeight = 500,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .35f, RangeHigh = .39f, DropWeight = 400,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .40f, RangeHigh = .44f, DropWeight = 300,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .45f, RangeHigh = .49f, DropWeight = 200,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .50f, RangeHigh = .54f, DropWeight = 100,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .02f, RangeHigh = .04f, DropWeight = 1000,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .05f, RangeHigh = .07f, DropWeight = 900,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .08f, RangeHigh = .10f, DropWeight = 800,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .13f, DropWeight = 700,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .14f, RangeHigh = .16f, DropWeight = 600,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .17f, RangeHigh = .19f, DropWeight = 500,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .20f, RangeHigh = .22f, DropWeight = 400,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .23f, RangeHigh = .25f, DropWeight = 300,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .26f, RangeHigh = .28f, DropWeight = 200,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .29f, RangeHigh = .31f, DropWeight = 100,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Back,
                EquipmentInventoryItem.EquipmentSlot.Hand,
                EquipmentInventoryItem.EquipmentSlot.Neck,
                EquipmentInventoryItem.EquipmentSlot.Weapon
            }
        },

        //Defensive
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .02f, RangeHigh = .04f, DropWeight = 1000,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .07f, DropWeight = 900,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .08f, RangeHigh = .10f, DropWeight = 800,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .11f, RangeHigh = .13f, DropWeight = 700,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .14f, RangeHigh = .16f, DropWeight = 600,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .17f, RangeHigh = .19f, DropWeight = 500,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .20f, RangeHigh = .22f, DropWeight = 400,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .23f, RangeHigh = .25f, DropWeight = 300,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .26f, RangeHigh = .28f, DropWeight = 200,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .29f, RangeHigh = .31f, DropWeight = 100,
            availableOn = new (){ EquipmentInventoryItem.EquipmentSlot.Arm,
                EquipmentInventoryItem.EquipmentSlot.Chest,
                EquipmentInventoryItem.EquipmentSlot.Foot,
                EquipmentInventoryItem.EquipmentSlot.Head,
                EquipmentInventoryItem.EquipmentSlot.Leg,
                EquipmentInventoryItem.EquipmentSlot.Shoulder,
                EquipmentInventoryItem.EquipmentSlot.Waist
            }
        },
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Water_Modifiers;
    }
}