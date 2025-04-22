using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class Equipment : ItemObject
{
    public float atkDamage;
    public float defenceAmount;
    public void Awake()
    {
        {
            type = ItemType.Weapons;
        }
    }
}
