using System.Collections.Generic;

public class DataObject
{
     //private List<ShopItem> _chosenItems;
    private int _endSum;
    private string _customersName;
    public string CustomersName => _customersName;
    //public IEnumerable<ShopItem> ChoosedItems => _chosenItems;
    public Dictionary<ShopItem, int> ChoosedItem;
    public DataObject()
    {
        ChoosedItem = new Dictionary<ShopItem, int>();
        _endSum = 0;
    }
    public bool DoesCantainsItems() => 
    public void AddItem(ShopItem item)
    {
        if( ChoosedItem.ContainsKey(item) )
        {
            ChoosedItem[item] += 1;
        }
        else
            ChoosedItem.Add(item, 1);
        _endSum += item.Price;
    }
    private void RemoveItem(ShopItem item)
    {
        ChoosedItem.Remove(item);
        _endSum -= item.Price;
    }
    public string GetOrderContentText()
    {
        string orderContent = _customersName + "@";
        int finalSum = 0;
        foreach(KeyValuePair<ShopItem, int> item in ChoosedItem)
        {
            finalSum += item.Value * item.Key.Price;
        }
        foreach(KeyValuePair<ShopItem, int> item in ChoosedItem)
        {
            orderContent = orderContent + "@" + item.Key.Title + "    " + item.Key.Price;
        }
        orderContent += "@@" + finalSum.ToString();
        orderContent = orderContent.Replace("@", System.Environment.NewLine);

        return orderContent;
    }

}
