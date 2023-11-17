using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "Shop")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _dishItemPrefab;

    public ShopItemView Get(ShopItem item, Transform parent)
    {
        ShopItemView instance = Instantiate(_dishItemPrefab, parent); // Returning not gameObject but ShopItemView, so later we can change some parameters in this instance
        instance.Initialize(item);
        return instance;
    }
}
