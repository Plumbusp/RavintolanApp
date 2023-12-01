using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrinkItem", menuName = "Shop/Drink Item")]
public class DrinkItem : ShopItem
{
    [field: SerializeField] public DrinkTypes DrinkType { get; private set; }
}
