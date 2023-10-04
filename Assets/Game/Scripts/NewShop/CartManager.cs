using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartManager 
{
    private List<FoodVariant> itemsInCart = new List<FoodVariant>();
    public void AddToCart(FoodVariant item)
    {
        itemsInCart.Add(item);
    }
    public void RemoveFromCart(FoodVariant item)
    {
        itemsInCart.Remove(item);
    }
    public void InstanciateAllItemsInCart(List<CartItem> cartItems)
    {
        List<FoodVariant> cleanItemsInCart = itemsInCart.GroupBy(n => );
        foreach (CartItem cartItem in cartItems)
        {
            ca
        }
    }
}
