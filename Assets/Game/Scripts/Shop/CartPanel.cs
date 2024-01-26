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

    }
    public void Clear()
    {

    }



    private class CartTypeSorter   // PAY ATTENTION TO AMOUNT OF THE ITEM TYPE currently 4  // SORT ITEMS BY TYPE
    {
       
    }
}
