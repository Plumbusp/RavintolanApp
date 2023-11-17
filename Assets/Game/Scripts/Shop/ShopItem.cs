using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField, Range(0,100000)] public int Price { get; private set; }

}
