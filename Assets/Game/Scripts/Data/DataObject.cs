using System.Collections.Generic;

public class DataObject
{
    private List<ShopItem> _chosenItems;
    private int _endSum;
    private string _customersName;
    public string CustomersName => _customersName;
    public IEnumerable<ShopItem> ChoosedItems => _chosenItems;
    public DataObject()
    {
        _chosenItems = new List<ShopItem>();
        _endSum = 0;
    }
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
    public string GetOrderContentText()
    {
        string orderContent = _customersName + "@";
        int finalSum = 0;
        foreach(ShopItem item in _chosenItems)
        {
            finalSum += item.Price;
        }
        foreach(ShopItem item in _chosenItems)
        {
            orderContent = orderContent + "@" + item.Title + "    " + item.Price;
        }
        orderContent += "@@" + finalSum.ToString();
        orderContent = orderContent.Replace("@", System.Environment.NewLine);

        return orderContent;
    }

}
