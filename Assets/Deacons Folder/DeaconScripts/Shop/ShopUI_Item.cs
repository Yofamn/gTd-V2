using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class ShopUI_Item : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Price;
    UnityAction<ShopItems> OnSelectedFn;
    [SerializeField] Image BackgroundPanel;
    [SerializeField] Color DefaultColor;
    [SerializeField] Color SelectedColor;
    ShopItems Item;
    public void Bind(ShopItems item, UnityAction<ShopItems> onSelectedFn){
        Item = item;
        OnSelectedFn = onSelectedFn;
        ItemName.text = Item.Name;
        Description.text = Item.Description;
        Price.text = $"{(Item.price)}";
        SetIsSelected(false);
    }
    public void SetIsSelected(bool selected){
        BackgroundPanel.color = selected ? SelectedColor : DefaultColor;
    }
    public void OnClicked(){
        OnSelectedFn.Invoke(Item);
    }
    public void SetCanAfford(bool canAfford){
        Price.fontStyle = canAfford ? FontStyles.Normal: FontStyles.Strikethrough;
        Price.color = canAfford ? Color.white: Color.red;
    }
}
