using System.Collections.Generic;

public class DataObject
{
    private List<ShopItem> _chosenItems;
    private List<CartItem> _boughtItems;
    private float _endSum;
    private int _maxNameLength = 20;

    private string _customerName;
    public IEnumerable<ShopItem> ChoosedItems => _chosenItems;
    public IEnumerable<CartItem> BoughtItems => _boughtItems;
    public DataObject()
    {
        _chosenItems = new List<ShopItem>();
        _boughtItems = new List<CartItem>();
        _endSum = 0;
    }
    public string CustomerName
    {
        private get
        { return _customerName; }
        set
        {
            if (value.Length > _maxNameLength)
            {
                _customerName = value.Substring(0, _maxNameLength);
                return;
            }
            _customerName = value;
        }
    }
    public string SpecialRequest{ private get; set; }
    public void AddItem(ShopItem item)
    {
        _chosenItems.Add(item);
        _endSum += item.Price;
    }
    public void RemoveItem(ShopItem item)
    {
        _chosenItems.Remove(item);
        _endSum -= item.Price;
    }
    public void SetItemsToBuy(List<CartItem> boughtItems)
    {
        _boughtItems = boughtItems;
    }
    public float GetOrderSum()
    {
        if(_boughtItems == null || _boughtItems.Count == 0)
            return 0;
        float finalSum = 0;
        foreach (CartItem item in _boughtItems)
        {
            float itemPrice = item.Amount * item.ShopItem.Price;
            finalSum += itemPrice;
        }
        return finalSum;
    }
    public string GetOrderContentText()
    {
        string orderContent = "Customer's name: " + _customerName;
        float finalSum = 0;
        orderContent += "@Special Requests: " + SpecialRequest + "@";
        orderContent += "@Order:";
        foreach (CartItem item in _boughtItems)
        {
            float itemPrice = item.Amount * item.ShopItem.Price;
            orderContent = orderContent + "@" + item.ShopItem.Title + "   Amount: " + item.Amount + "    " + itemPrice + "€";
            finalSum += itemPrice;
        }
        orderContent += "@@" + "Final sum: " + finalSum.ToString() + "€";
        orderContent = orderContent.Replace("@", System.Environment.NewLine);

        return orderContent;
    }

}
