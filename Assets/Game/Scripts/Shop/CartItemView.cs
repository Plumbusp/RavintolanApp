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
    public ShopItem Item { get; private set; }
    private int _amount;
    private int _price;
    
    //public int Price
    //{
    //    get
    //    {
    //        return _price;
    //    }
    //    set
    //    {
    //        if (((Item.Price + value) % Item.Price) != 0)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(value));
    //        }
    //        _price += value;
    //    }
    //}
    public void Initialize(ShopItem item)
    {
        this.Item = item;
        _image.sprite = item.Image;
        _specialSign.sprite = item.SpecialSign;
        _title.text = item.Title;
        _priceView.text = _price.ToString();
        _price = item.Price * _amount;
        _priceView.text = _price.ToString();
    }
    public void Set
}
