using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartItem
{
    public Sprite Image;
    public string Title;
    public int Price;
    public Sprite SpecialSign;
    public int Amount;

    public CartItem(ShopItem shopItem)
    {
        Image = shopItem.Image;
        Title = shopItem.Title;
        Price = shopItem.Price;
        SpecialSign = shopItem.SpecialSign;
    }
}
