using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopPanel panel;
    [SerializeField] private ShopContent content;
    [Header("Category Buttons")]
    [SerializeField] ShopCategoryButton _appetizers;
    [SerializeField] ShopCategoryButton _desserts;
    [SerializeField] ShopCategoryButton _mainDish;
    [SerializeField] ShopCategoryButton _drinks;

    private void OnEnable()
    {
        _appetizers.Click += OnAppetizersClick;
        _desserts.Click += OnDessertsClick;
        _mainDish.Click += OnMainDishClick;
        _drinks.Click += OnDrinksClick;
    }
    private void OnDisable()
    {
        _appetizers.Click -= OnAppetizersClick;
        _desserts.Click -= OnDessertsClick;
        _mainDish.Click -= OnMainDishClick;
        _drinks.Click -= OnDrinksClick;
    }
    public void OnAppetizersClick()
    {
        panel.Show(content.AppetizerItems);
    }
    public void OnDessertsClick()
    {
        panel.Show(content.DessertItems);
    }
    public void OnMainDishClick()
    {
        panel.Show(content.MainDishItems);
    }
    public void OnDrinksClick()
    {
        panel.Show(content.DrinkItems);
    }

}
