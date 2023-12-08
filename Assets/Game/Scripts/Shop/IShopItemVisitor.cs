using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItemVisitor 
{
    public void Visit(ShopItem item);
    public void Visit(AppetizerItem item);
    public void Visit(MainDishItem item);
    public void Visit(DessertItem item);
    public void Visit(DrinkItem item);
}
