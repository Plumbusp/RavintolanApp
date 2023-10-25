using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class CartManager 
{
    private List<FoodVariant> itemsInCart = new List<FoodVariant>();
    List<GameObject> cartBlocks;
    private Queue<GameObject> cartBlocksQueue;

    public CartManager(List<GameObject> cartBlocks)
    {
        this.cartBlocks = cartBlocks;
    }

    public void AddToCart(FoodVariant item)   //  add item to cart
    {
        itemsInCart.Add(item);
    }
    public void RemoveFromCart(FoodVariant item)
    {
        itemsInCart.Remove(item);            // remove item from cart
    }
    public void InstanciateAllItemsInCart()   // method that returns list of ready-to-use cart blocks 
    {
        foreach(var cartBlock in cartBlocks)
        {
            cartBlocksQueue.Enqueue(cartBlock);
        }

        List<CartBlockAbstract> abstractItemsInCart = new List<CartBlockAbstract>();
        var groupedItems = itemsInCart.GroupBy(x => x.foodID).ToList();  // Grouping choosed items in our cart, to search for dublicates
        foreach(List<FoodVariant> groupedItem in groupedItems)
        {
            if (groupedItem.Count() > 1)
            {   
                int amount = 0;
                foreach (FoodVariant item in groupedItem)
                {
                    amount++;
                    groupedItem.Remove(item);
                }
                abstractItemsInCart.Add(new CartBlockAbstract(groupedItem[0].foodImage, groupedItem[0].foodName, amount));
            }
            else if(groupedItem.Count() == 1)
            {
                foreach (FoodVariant item in groupedItem)
                {
                    abstractItemsInCart.Add(new CartBlockAbstract(groupedItem[0].foodImage, groupedItem[0].foodName, 1));
                }
            }
        }
        foreach(var item in abstractItemsInCart)
        {
            if (cartBlocksQueue.Count > 0)
            {
                if (cartBlocksQueue.Dequeue().TryGetComponent<CartBlockMono>(out CartBlockMono cartMonobeh))
                {
                    cartMonobeh.SetImage(item.image);
                    cartMonobeh.SetName(item.foodName);
                    cartMonobeh.SetAmount(item.count);
                }
            }
        }
    }

    public class CartBlockAbstract
    {
        public CartBlockAbstract(Sprite image, string foodName, int count)
        {
            this.image = image;
            this.foodName = foodName;
            this.count = count;
        }

        public Sprite image;
        public string foodName;
        public int count;
    }
}
