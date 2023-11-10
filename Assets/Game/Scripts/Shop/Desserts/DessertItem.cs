using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DessertItem", menuName = "Shop/Dessert Item")]
public class DessertItem : ShopItem
{
    [field: SerializeField] public DessertTypes DessertType { get; private set; }
}
