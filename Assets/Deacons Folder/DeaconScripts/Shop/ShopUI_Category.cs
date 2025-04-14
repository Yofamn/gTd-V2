using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ShopUI_Category : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CategoryName;
    ShopItemCategory Category;

    public void Bind(ShopItemCategory category,UnityAction<ShopItemCategory> onSelectedFn){
        Category = category;
        CategoryName.text = Category.Name;
    }
}
