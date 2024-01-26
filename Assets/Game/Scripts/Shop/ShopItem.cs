using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : ScriptableObject
{
    public FoodType FoodType;
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField, Range(0,100)] public int Price { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite SpecialSign { get; private set; }
}
