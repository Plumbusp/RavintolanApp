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
    private ShopItemsSorter _shopItemsSorter = new ShopItemsSorter();

    public void Show(List<ShopItem> items)
    {
        if (items == null)
            return;
        var sortedItems = _shopItemsSorter.SortFromShopItemsToCartItems(items);

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
}
public class ShopItemsSorter
{
    public List<CartItem> SortFromShopItemsToCartItems(List<ShopItem> shopItemsToSort)
    {
        List<CartItem> cartItems = new List<CartItem>();
        var sortedShopItems = shopItemsToSort.GroupBy(item => item.Title).Where(item => item.Count() > 1).ToList();
        foreach (var shopItems in sortedShopItems)
        {
            CartItem cartItem = new CartItem(shopItems.ToList());
            cartItems.Add(cartItem);
        }
        return cartItems;
    }
}
