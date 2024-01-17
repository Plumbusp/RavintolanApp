using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;
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
    public void Initialize(PersistantData persistantData)
    {
        _shopPanel.Initialize(persistantData);
    }
    public void OnAppetizersClick()
    {
        _shopPanel.Show(content.AppetizerItems);
    }
    public void OnDessertsClick()
    {
        _shopPanel.Show(content.DessertItems);
    }
    public void OnMainDishClick()
    {
        _shopPanel.Show(content.MainDishItems);
    }
    public void OnDrinksClick()
    {
        _shopPanel.Show(content.DrinkItems);
    }
}