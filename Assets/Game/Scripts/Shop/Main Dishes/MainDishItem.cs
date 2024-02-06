using UnityEngine;

[CreateAssetMenu(fileName = "MainDishItem", menuName = "Shop/MainDish Item")]
public class MainDishItem : ShopItem
{
    [field: SerializeField] public MainDishTypes DishType { get; private set; }
}
