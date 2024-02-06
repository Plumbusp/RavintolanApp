using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    [Header("Shop")]
    [SerializeField] private Shop _shop;

    [Header("Cart")]
    [SerializeField] private Cart _cart;
    [SerializeField] private CartButton _cartOpenButton;
    [SerializeField] private CartButton _cartCloseButton;

    [Header("Personal Info Input Panel")]
    [SerializeField] private GameObject _personalInfoPanel;

    [Header("Thank you panel")]
    [SerializeField] private GameObject _thankYouPanel;

    private void OnEnable()
    {
        Cart.OnNextStep += OpenPersonalInfoPanel;
        PersonalInfoController.OnNextStep += OpenThankYouPanel;
        _cartOpenButton.Click += OpenCart;
        _cartCloseButton.Click += CloseCart;
    }
    private void OnDisable()
    {
        Cart.OnNextStep -= OpenPersonalInfoPanel;
        PersonalInfoController.OnNextStep -= OpenThankYouPanel;
        _cartOpenButton.Click -= OpenCart;
        _cartCloseButton.Click -= CloseCart;
    }
    public void CloseThankYouPanel()
    {
        _thankYouPanel.SetActive(false);
        _shop.Open();
    }
    private void OpenCart()
    {
        _shop.Close();
        _cart.Open();
    }
    private void CloseCart()
    {
        _shop.Open();
        _cart.Close();
    }
    private void OpenPersonalInfoPanel()
    {
        _cart.Close();
        _shop.Close();
        _personalInfoPanel.SetActive(true);
    }
    private void OpenThankYouPanel()
    {
        _personalInfoPanel.SetActive(false);
        _thankYouPanel.SetActive(true);
    }
}
