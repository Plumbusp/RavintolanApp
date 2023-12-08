using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    [SerializeField] private CartPanel _cartPanel;
    [Header("Buttons")]
    [SerializeField] private CartButton _cartButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _buyButton;
    private void OnEnable()
    {
        _cartButton.Click += OpenCart;
        _returnButton.onClick.AddListener(CloseCart);
        _buyButton.onClick.AddListener(MakeOrder);
    }
    private void OnDisable()
    {
        _cartButton.Click -= OpenCart;
        _returnButton.onClick.RemoveListener(CloseCart);
        _buyButton.onClick.RemoveListener(MakeOrder);
    }
    private void OpenCart()
    {
        _cartPanel.Show(PersistentData.OrderDataObject.ChoosedItems);
    }
    private void CloseCart()
    {
        _cartPanel.Clear();
    }
    private void MakeOrder() // Or buy with different make order
    {
        Debug.Log("Bought!");
    }
}
