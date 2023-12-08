using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartPanel : MonoBehaviour
{
    [SerializeField] private CartItemViewFactory _cartItemViewFactory;
    [SerializeField] private Transform _parentTransform;
    private List<CartItemView> _cartItems = new List<CartItemView>();
    private CartTypeSorter _cartSorter = new CartTypeSorter();
    public void Show(IEnumerable<ShopItem> items)
    {
        var sortedItems = _cartSorter.SortItems(items);
        foreach (var item in sortedItems)
        {
            var instance = _cartItemViewFactory.Get(item, _parentTransform);
            _cartItems.Add(instance);
        }
    }
    public void Clear()
    {
        foreach (CartItemView item in _cartItems)
        {
            Destroy(item.gameObject);
        }
        _cartItems.Clear();
    }
    private class CartTypeSorter   // PAY ATTENTION TO AMOUNT OF THE ITEM TYPE currently 4  // SORT ITEMS BY TYPE
    {
        private List<ShopItem> mainDishItems;   //4   each type has its of list
        private List<ShopItem> appetizerItems;
        private List<ShopItem> dessertItems;
        private List<ShopItem> drinkItems;
        public IEnumerable<ShopItem> SortItems(IEnumerable<ShopItem> items)  // method called to sort items by type. It returnes sorted IEnumaerable.
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            foreach(ShopItem item in items)
            {
                Visit(item);
            }
            List<ShopItem> sortedItems = new List<ShopItem>();
            sortedItems.AddRange(mainDishItems);    //4   making one common list
            sortedItems.AddRange(appetizerItems);
            sortedItems.AddRange(dessertItems);
            sortedItems.AddRange(drinkItems);
            return sortedItems;
        }
        private void Visit(ShopItem item) => Visit((dynamic)item);   // partly using visitor pattern  
        private void Visit(AppetizerItem item)
        {
            appetizerItems.Add(item);
        }
        private void Visit(MainDishItem item)
        {
            appetizerItems.Add(item);
        }

        private void Visit(DessertItem item)
        {
            appetizerItems.Add(item);
        }

        private void Visit(DrinkItem item)
        {
            appetizerItems.Add(item);
        }
    }
}
