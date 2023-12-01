using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemView : MonoBehaviour
{
    public ShopItem Item { get; private set; }

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _specialSign;

    public void Initialize(ShopItem item)
    {
        this.Item = item;
        _image.sprite = item.Image;
        _title.text = item.Title;
        _price.text = item.Price.ToString();
    }
}
