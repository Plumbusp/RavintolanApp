using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopItem : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public float Price { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite SpecialSign { get; private set; }
}

public class ShopItemEqualityComparer : IEqualityComparer<ShopItem>
{
    public bool Equals(ShopItem x, ShopItem y)
    {
        return x.Price == y.Price && x.Title == y.Title; 
    }

    public int GetHashCode(ShopItem obj)
    {
        return HashCode.Combine(obj.Price, obj.Title, obj.Image, obj.Description, obj.SpecialSign);
    }
}
