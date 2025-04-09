using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUI_Category : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CategoryName;
    ShopItemCategory Category;

    public void Bind(ShopItemCategory category){
        Category = category;
        CategoryName.text = Category.Name;
    }
}
