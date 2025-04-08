using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item", fileName = "ShopItem_")]
public class ShopItems : ScriptableObject
{
    public ShopItemCategory Category;
    public string Name;
    [TextArea(3,5)]public string Description;
    public int price;

}
