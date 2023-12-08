using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CartItemViewFactory", menuName = "Shop/CartItemViewFactory")]
public class CartItemViewFactory : ScriptableObject
{
    [SerializeField] private CartItemView _cartItemPrefab;
    public CartItemView Get(ShopItem item,Transform transform)
    {
        CartItemView instance = Instantiate(_cartItemPrefab, transform);
        instance.Initialize(item);
        return instance;
    }
}
