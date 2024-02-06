using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class CartItem
{
    public ShopItem ShopItem;
    public int Amount;

    public CartItem(List<ShopItem> shopitems)
    {
        if(shopitems.GroupBy(item => item.Title).Count() != 1)
            throw new Exception(nameof(shopitems));
        ShopItem = shopitems[0];
        Amount = shopitems.Count();
    }
}
