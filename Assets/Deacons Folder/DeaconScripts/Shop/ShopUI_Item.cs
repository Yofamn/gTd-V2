using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUI_Item : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Price;
    ShopItems Item;
    public void Bind(ShopItems item){
        Item = item;

        ItemName.text = Item.Name;
        Description.text = Item.Description;
        Price.text = $"{(Item.price)}";
    }
}
