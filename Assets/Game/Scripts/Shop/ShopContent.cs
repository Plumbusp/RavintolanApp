using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu (fileName = "ShopContent" , menuName = "Shop/Shop Content(Container)")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<AppetizerItem> _appetizerItems = new List<AppetizerItem>();
    [SerializeField] private List<MainDishItem> _mainDishItems = new List<MainDishItem>();
    [SerializeField] private List<DessertItem> _dessertItems = new List<DessertItem>();
    [SerializeField] private List<DrinkItem> _drinkItem = new List<DrinkItem>();

    public IEnumerable<DessertItem>  DessertItems => _dessertItems;
    public IEnumerable<AppetizerItem> AppetizerItems => _appetizerItems;
    public IEnumerable<MainDishItem> MainDishItems => _mainDishItems;
    public IEnumerable<DrinkItem> DrinkItems => _drinkItem;
    private void OnValidate()
    {
        _dessertItems = _dessertItems.Distinct(new ShopItemEqualityComparer()).Cast<DessertItem>().ToList();
        _appetizerItems = _appetizerItems.Distinct(new ShopItemEqualityComparer()).Cast<AppetizerItem>().ToList();
        _mainDishItems = _mainDishItems.Distinct(new ShopItemEqualityComparer()).Cast<MainDishItem>().ToList();
        _drinkItem = _drinkItem.Distinct(new ShopItemEqualityComparer()).Cast<DrinkItem>().ToList();
    }
}
