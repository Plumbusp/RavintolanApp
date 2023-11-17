using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ShopItemView : MonoBehaviour
{
    public event Action<ShopItem> AddToCartClick;
    [SerializeField] private Button _cartButton;
    [SerializeField] private Image _standartBackground;
    [SerializeField] private Image _highlightedBackground;
    [SerializeField] private ValueView<int> _priceView;   

    public ShopItem Item { get; private set; }
    public int Price => Item.Price;

    private Image _backgroundImage;
    public void Initialize(ShopItem item)
    {
         Item = item;
        _cartButton.onClick.AddListener(() => AddToCartClick?.Invoke(Item));
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standartBackground.sprite;
        _priceView.Show(Price);  //we are showing price by default 
    }
    public void Highlighte() => _backgroundImage.sprite = _highlightedBackground.sprite;
    public void UnHighlighte() => _backgroundImage.sprite = _standartBackground.sprite;
}
