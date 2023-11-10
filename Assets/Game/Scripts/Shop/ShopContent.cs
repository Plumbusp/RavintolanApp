using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu (fileName = "ShopContent" , menuName = "Shop/Shop Content(Container)")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<DessertItem> _dessertItems;
    [SerializeField] private List<AppetizerItem> _appetizerItems;
    public IEnumerable <DessertItem> DessertItems => _dessertItems;
    public IEnumerable <AppetizerItem> AppetizerItems => _appetizerItems;
    private void OnValidate()
    {
        var dessertItemsDublicates = _dessertItems.GroupBy(item => item.DessertType).Where(dublicates => dublicates.Count() > 1);
        if(dessertItemsDublicates.Count()> 0)
            throw new InvalidOperationException(nameof(_dessertItems));

        var appetizersItemsDublicates = _appetizerItems.GroupBy(item => item.AppetizerType).Where(dublicates => dublicates.Count() > 1);
        if (appetizersItemsDublicates.Count() > 0)
            throw new InvalidOperationException(nameof(_appetizerItems));
    }

}
