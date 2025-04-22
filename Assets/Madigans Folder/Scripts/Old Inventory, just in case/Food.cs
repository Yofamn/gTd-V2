using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class Food : ItemObject
{
    public int restoreHealthValue;
    public void Awake()
    {     
        {
            type = ItemType.Food;
        }
    }
}
