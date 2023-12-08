using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemView : MonoBehaviour
{
    
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _priceView;
    [SerializeField] private Image _specialSign;
    private int _amount;
    public ShopItem Item { get; private set; }
    public int Amount => _amount;
    public int Price
    {
        get
        {
            return Price;
        }
        set
        {
            if (((Item.Price + value) % Item.Price) != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            Price += value;
        }
    }
    public void Initialize(ShopItem item)
    {
        this.Item = item;
        _image.sprite = item.Image;
        _title.text = item.Title;
        Price = item.Price;
    }
}
