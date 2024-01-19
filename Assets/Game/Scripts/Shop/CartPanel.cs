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
        if (items == null)
            return;
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
        private List<ShopItem> mainDishItems = new List<ShopItem>();   //4   each type has its of list
        private List<ShopItem> appetizerItems = new List<ShopItem>();
        private List<ShopItem> dessertItems = new List<ShopItem>();
        private List<ShopItem> drinkItems = new List<ShopItem>();
        List<CartItem> sortedItems = new List<CartItem>();
        public IEnumerable<CartItem> SortItems(IEnumerable<ShopItem> items)  // method called to sort items by type. It returnes sorted IEnumaerable.
        {
            sortedItems.Clear();

            if (items == null)
            {
                throw new ArgumentNullException("items are null");
            }
            foreach(ShopItem item in items)
            {
                Visit(item);
            }

            //4   making one common list
            if(mainDishItems.Count > 0)
            {
                var mainDishitemsDublicates = mainDishItems.GroupBy(item => item.Title).Where(array => array.Count() > 1);
                if(mainDishitemsDublicates.Count() > 0)
                {
                }
            }
            return sortedItems;
        }
        private void Visit(ShopItem item) => Visit((dynamic)item);   // partly using visitor pattern  
        private void Visit(AppetizerItem item)
        {
            sortedItems.Add(new CartItem(item));
        }
        private void Visit(MainDishItem item)
        {
            sortedItems.Add(new CartItem(item));
        }

        private void Visit(DessertItem item)
        {
            sortedItems.Add(new CartItem(item));
        }

        private void Visit(DrinkItem item)
        {
            sortedItems.Add(new CartItem(item));
        }
    }
}
