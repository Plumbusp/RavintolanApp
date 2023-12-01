using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartPanel : MonoBehaviour
{
   public void Show(IEnumerable<ShopItem> items)
    {
        var sortedItems = items.GroupBy(item => item.)
        foreach(ShopItem item in items) {
          
        }

    }
    private class CartSorter
    {
        private IEnumerable<ShopItemView> _items;
        public CartSorter(IEnumerable<ShopItemView> items)
        {
            _items = items;
        }
        public IEnumerable<ShopItem> SortItems()
        {
            List<>
        }
    }
}
