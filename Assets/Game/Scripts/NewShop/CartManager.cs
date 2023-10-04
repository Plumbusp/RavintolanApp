using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class CartManager 
{
    private List<FoodVariant> itemsInCart = new List<FoodVariant>();
    public void AddToCart(FoodVariant item)   //  add item to cart
    {
        itemsInCart.Add(item);
    }
    public void RemoveFromCart(FoodVariant item)
    {
        itemsInCart.Remove(item);            // remove item from cart
    }
    public List<CartBlockAbstract> InstanciateAllItemsInCart()   // method that returns list of ready-to-use cart blocks 
    {
        List<CartBlockAbstract> cartBlocks = new List<CartBlockAbstract>();

        var cleanItemsInCart = itemsInCart.GroupBy(x => x.foodID).ToList();  // Grouping choosed items in our cart, to search for dublicates
        foreach(List<FoodVariant> cleanItem in cleanItemsInCart)
        {
            if (cleanItem.Count() > 1)
            {   
                int amount = 0;
                foreach (FoodVariant item in cleanItem)
                {
                    amount++;
                    cleanItem.Remove(item);
                }
                cartBlocks.Add(new CartBlockAbstract(cleanItem[0].foodImage, cleanItem[0].foodName, amount));
            }
            else if(cleanItem.Count() == 1)
            {
                foreach (FoodVariant item in cleanItem)
                {
                    cartBlocks.Add(new CartBlockAbstract(cleanItem[0].foodImage, cleanItem[0].foodName, 1));
                }
            }
        }
        return cartBlocks;
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
