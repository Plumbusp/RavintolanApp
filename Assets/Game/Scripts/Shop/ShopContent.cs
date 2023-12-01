using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu (fileName = "ShopContent" , menuName = "Shop/Shop Content(Container)")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<AppetizerItem> _appetizerItems;
    [SerializeField] private List<MainDishItem> _mainDishItems;
    [SerializeField] private List<DessertItem> _dessertItems;
    [SerializeField] private List<DrinkItem> _drinkItem;

    public IEnumerable<DessertItem>  DessertItems => _dessertItems;
    public IEnumerable<AppetizerItem> AppetizerItems => _appetizerItems;
    public IEnumerable<MainDishItem> MainDishItems => _mainDishItems;
    public IEnumerable<DrinkItem> DrinkItems => _drinkItem;
    private void OnValidate()
    {
        var dessertItemsDublicates = _dessertItems.GroupBy(item => item.DessertType)
            .Where(array => array.Count() > 1);
        if (dessertItemsDublicates?.Count() > 0)
        {
            throw new InvalidOperationException(nameof(dessertItemsDublicates));
        }
        var appetizerItemsDublicate = _appetizerItems.GroupBy(item => item.AppetizerType)
        .Where(array => array.Count() > 1);
        if (appetizerItemsDublicate?.Count() > 0)
        {
            throw new InvalidOperationException(nameof(appetizerItemsDublicate));
        }
    }
}
