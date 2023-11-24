using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;
    [SerializeField] private Transform _parentTransform;
    private List<ShopItemView> shopItems = new List<ShopItemView>();
    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();
        foreach(ShopItem item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _parentTransform);
            spawnedItem.CartClick += OnAddToCartClick;
            shopItems.Add(spawnedItem);
        }
    }

    private void OnAddToCartClick(ShopItem item)
    {
        Debug.Log(item.Price);
    }

    private void Clear()
    {
        foreach(ShopItemView item in shopItems)
        {
            item.CartClick -= OnAddToCartClick;
            Destroy(item.gameObject);
        }
        shopItems.Clear();
        // Clear all previous data 
    }
}
