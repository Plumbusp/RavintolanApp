using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private CartButton _cartButton;
    [SerializeField] private Button _return;
    [SerializeField] private Button buy;
    private void OnEnable()
    {
        _cartButton.Click += OpenCart;
    }
    private void OpenCart()
    {
        //
    }
    private void CloseCart()
    {
        //
    }
    private void MakeOrder() // Or buy with different make order
    {

    }
}
