using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemView : MonoBehaviour
{
    [SerializeField] private Button _addAmountButton;
    [SerializeField] private Button _decreaseAmountButton;
    [SerializeField] private TMP_Text _amountView;

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _priceView;
    [SerializeField] private Image _specialSign;
    public CartItem Item { get; private set; }
    private float _price;
    private void OnEnable()
    {
        _addAmountButton.onClick.AddListener(AddAmount);
        _decreaseAmountButton.onClick.AddListener(DecreasAmount);
    }
    private void OnDisable()
    {
        _addAmountButton.onClick.RemoveAllListeners();
        _decreaseAmountButton.onClick.RemoveAllListeners();
    }
    public void Initialize(CartItem item)
    {
        this.Item = item;
        _image.sprite = item.ShopItem.Image;
        _specialSign.sprite = item.ShopItem.SpecialSign;
        _title.text = item.ShopItem.Title;
        _amountView.text = Item.Amount.ToString();
        UpdateTotalSum();
    }
    private void AddAmount()
    {
        if (Item.Amount >= 9)
            return;
        Item.Amount++;
        _amountView.text = Item.Amount.ToString();
        UpdateTotalSum();
    }
    private void DecreasAmount()
    {
        if (Item.Amount <= 0)
            return;
        Item.Amount--;
        _amountView.text = Item.Amount.ToString();
        UpdateTotalSum();
    }
    private void UpdateTotalSum()
    {
        _price = Item.ShopItem.Price * Item.Amount;
        _priceView.text = _price.ToString() + "€";
    }
}
