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

}
