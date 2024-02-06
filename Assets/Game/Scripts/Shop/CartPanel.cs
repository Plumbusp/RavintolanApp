using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartPanel : MonoBehaviour
{
    [SerializeField] private CartItemViewFactory _cartItemViewFactory;
    [SerializeField] private Transform _parentTransform;
    public List<CartItemView> CartItems { get; private set;}
    private ShopItemsSorter _shopItemsSorter = new ShopItemsSorter();

    private void Awake()
    {
        CartItems = new List<CartItemView>();
    }
    public void Show(List<ShopItem> items)
    {
        if (items == null)
            return;
        var sortedItems = _shopItemsSorter.SortFromShopItemsToCartItems(items);

        foreach (var item in sortedItems)
        {
            var instance = _cartItemViewFactory.Get(item, _parentTransform);
            CartItems.Add(instance);
        }
    }
    public void Clear()
    {
        foreach (CartItemView item in CartItems)
        {
            Destroy(item.gameObject);
        }
        CartItems.Clear();
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
