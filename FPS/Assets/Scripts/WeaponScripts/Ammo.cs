using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Ammo : MonoBehaviour
{
    [SerializeField]
    private List<AmmoSlot> ammoSlots = new List<AmmoSlot>()
    {
        new AmmoSlot(AmmoType.bullets, 30),
        new AmmoSlot(AmmoType.shells, 15),
        new AmmoSlot(AmmoType.sniperBullets, 10),
    };

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoType(ammoType);
        return ammoSlot.ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoType(ammoType);
        ammoSlot.ammoAmount--;
    }
    
    public int IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        var ammoSlot = GetAmmoType(ammoType);
        ammoSlot.ammoAmount += ammoAmount;

        return ammoSlot.ammoAmount;
    }

    private AmmoSlot GetAmmoType(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
