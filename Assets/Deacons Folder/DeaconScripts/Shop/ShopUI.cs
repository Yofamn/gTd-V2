using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AvailableFunds;
    [SerializeField] Transform CategoryUIRoot;
    [SerializeField] Transform ItemUIRoot;

    [SerializeField] GameObject CategoryUIPrefab;
    [SerializeField] GameObject ItemUIPrefab;
    [SerializeField] List<ShopItems> AvailableItems;
    List<ShopItemCategory> ShopCategories;
    ShopItemCategory SelectedCategory;
    Dictionary<ShopItemCategory, ShopUI_Category> ShopCategoryToUIMap;

    void Start(){
        RefreshShopUI();
    }
    void RefreshShopUI(){

        ShopCategories = new List<ShopItemCategory>();
        ShopCategoryToUIMap = new Dictionary<ShopItemCategory, ShopUI_Category>();

        //determine category list
        foreach(var item in AvailableItems){
            if(!ShopCategories.Contains(item.Category))
                ShopCategories.Add(item.Category);
        }

        ShopCategories.Sort((lhs,rhs)=>lhs.Name.CompareTo(rhs.Name));

        //instantiate the categories
        foreach(var category in ShopCategories){

            var categoryGO = Instantiate(CategoryUIPrefab, CategoryUIRoot);
            var categoryUI = categoryGO.GetComponent<ShopUI_Category>();

            categoryUI.Bind(category, onCategorySelected);
            ShopCategoryToUIMap[category] = categoryUI;

        }

        if(!ShopCategories.Contains(SelectedCategory)){
            SelectedCategory = null;
        }
        onCategorySelected(SelectedCategory);
           
    } 
    void RefreshShopUI_Items(){

    }
    void onCategorySelected(ShopItemCategory newlySelectedCategory){
        //updata the selection
        SelectedCategory = newlySelectedCategory;
        foreach(var category in ShopCategories){
            ShopCategoryToUIMap[category].SetIsSelected(category == SelectedCategory);
        }
        RefreshShopUI_Items();
    }
    public void OnClickedPurchase(){

    }
    public void OnClickedExit(){

    }
    
}
