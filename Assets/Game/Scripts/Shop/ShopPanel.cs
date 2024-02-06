using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;
    [SerializeField] private Transform _parentTransform;

    private PersistantData _persistantData;
    private List<ShopItemView> shopItems = new List<ShopItemView>();

    public void Initialize(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }

    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();
        foreach(ShopItem item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _parentTransform);
            spawnedItem.OnAddToCartClick += OnAddToCartClick;
            shopItems.Add(spawnedItem);
        }
    }

    private void OnAddToCartClick(ShopItem item)
    {
        _persistantData.OrderDataObject.AddItem(item);
    }

    private void Clear()
    {
        foreach(ShopItemView item in shopItems)
        {
            item.OnAddToCartClick -= OnAddToCartClick;
            Destroy(item.gameObject);
        }
        shopItems.Clear();
        // Clear all previous data 
    }
}
