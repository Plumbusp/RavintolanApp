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
    public CartItem Item { get; private set; }
    private int _amount;
    private int _price;
    
    public void Initialize(CartItem item)
    {
        this.Item = item;
        _image.sprite = item.Image;
        _specialSign.sprite = item.SpecialSign;
        _title.text = item.Title;
        _priceView.text = _price.ToString();
        _amount = item.Amount;
        _price = item.Price * _amount;
        _priceView.text = _price.ToString();
    }
}
