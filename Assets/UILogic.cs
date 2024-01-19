using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    [Header("Cart")]
    [SerializeField] private Cart _cart;

    [SerializeField] private CartButton _cartOpenButton;
    [SerializeField] private CartButton _cartCloseButton;

    [Header("Thank you panel")]
    [SerializeField] private GameObject _thankYouPanel;

    private void OnEnable()
    {
        _cart.OnOrderMade += OpenThankYouTab;
        _cartOpenButton.Click += OpenCart;
        _cartCloseButton.Click += CloseCart;
    }
    private void OnDisable()
    {
        _cart.OnOrderMade -= OpenThankYouTab;
        _cartOpenButton.Click -= OpenCart;
        _cartCloseButton.Click -= CloseCart;
    }
    public void CloseThankYouPanel()
    {
        _thankYouPanel.SetActive(false);
    }
    private void OpenCart()
    {
        _cart.gameObject.SetActive(true);
        _shop.gameObject.SetActive(false);
        _cart.Open();
    }
    private void CloseCart()
    {
        _cart.gameObject.SetActive(false);
        _shop.gameObject.SetActive(true);
        _cart.Close();
    }
    private void OpenThankYouTab()
    {
        _thankYouPanel.SetActive(true);
        CloseCart();
    }
}
