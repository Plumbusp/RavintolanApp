using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject _cart;
    [SerializeField] private GameObject _theShop;

    [SerializeField] private ShopPanel panel;
    [SerializeField] private ShopContent content;
    [Header("Category Buttons")]
    [SerializeField] ShopCategoryButton _appetizers;
    [SerializeField] ShopCategoryButton _desserts;
    [SerializeField] ShopCategoryButton _mainDish;
    [SerializeField] ShopCategoryButton _drinks;

    [Header("Cart")]
    [SerializeField] private CartPanel _cartPanel;
    [Header("Cart Buttons")]
    [SerializeField] private CartButton _cartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _buyButton;
    private void OnEnable()
    {
        _appetizers.Click += OnAppetizersClick;
        _desserts.Click += OnDessertsClick;
        _mainDish.Click += OnMainDishClick;
        _drinks.Click += OnDrinksClick;

        _cartButton.Click += OnOpenCart;
        _returnButton.onClick.AddListener(OnCloseCart);
        _buyButton.onClick.AddListener(OnMakeOrder);
    }
    private void OnDisable()
    {
        _appetizers.Click -= OnAppetizersClick;
        _desserts.Click -= OnDessertsClick;
        _mainDish.Click -= OnMainDishClick;
        _drinks.Click -= OnDrinksClick;

        _cartButton.Click -= OnOpenCart;
        _returnButton.onClick.RemoveListener(OnCloseCart);
        _buyButton.onClick.RemoveListener(OnMakeOrder);
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

    private void OnOpenCart()
    {
        _cartPanel.Show(PersistentData.OrderDataObject.ChoosedItems);
    }
    private void OnCloseCart()
    {
        _cartPanel.Clear();
    }
    private void OnMakeOrder() // Or buy with different make order
    {
        Debug.Log("Bought!");
    }
}