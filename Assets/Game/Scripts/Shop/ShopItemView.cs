using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Image))]
public class ShopItemView : MonoBehaviour
{
    public event Action<ShopItem> OnAddToCartClick;
    [Header("Buttons")]
    [SerializeField] private Button _addToCartButton;
    [SerializeField] private Button _descriptionButton;
    [Header("Images ect.")]
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image _imageForSpecialSign;
    [SerializeField] private GameObject _descriptionPanel;
    [SerializeField] private Color _standartBackground;
    [SerializeField] private Color _highlightedBackground;
    [Header("Texts")]
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private ValueView<int> _priceView;
    [SerializeField] private TMP_Text _title;
    public ShopItem Item { get; private set; }
    public int Price => Item.Price;

    public void Initialize(ShopItem item)
    {
         Item = item;

        _addToCartButton.onClick.AddListener(() => OnAddToCartClick?.Invoke(Item));
        _descriptionButton.onClick.AddListener(ShowDescription);

        _foodImage.sprite = item.Image;
        _title.text = item.Title;
        _imageForSpecialSign.sprite = item.SpecialSign;
        _descriptionText.text = item.Description;
        _backgroundImage.color = _standartBackground;
        _priceView.Show(Price);  //we are showing price by default 
    }
    public void Highlighte() => _backgroundImage.color = _highlightedBackground;
    public void UnHighlighte() => _backgroundImage.color = _standartBackground;
    private void ShowDescription()
    {
        if (_descriptionPanel.activeSelf)
        {
            _descriptionPanel.SetActive(false);
            _descriptionButton.GetComponent<ButtonExtras>().buttonText.text = "Description";
        }
        else
        {
            _descriptionPanel.SetActive(true);
            _descriptionButton.GetComponent<ButtonExtras>().buttonText.text = "Return";
        }

    }
}
