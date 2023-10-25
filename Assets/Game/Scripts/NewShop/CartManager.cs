using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class CartManager 
{
    List<ItemVariant> foodVariants;   //Variants of food
    List<GameObject> foodBlocks;  //Gameobject blocks locks Of Food
    private List<ItemVariant> itemsInCart = new List<ItemVariant>();  //All food variants in cart
    private List<GameObject> cartBlocks = new List<GameObject>();

    public CartManager(List<ItemVariant> foodVariants, List<GameObject> foodBlocks, List<GameObject> cartBlocks)
    {
        this.foodVariants = foodVariants;
        this.foodBlocks = foodBlocks;
    }

    public void FullAllBlocks()
    {
        Queue<GameObject> foodBlocksQueue = new Queue<GameObject>();  // Queue for handaling filling
        foreach (var block in foodBlocks)
        {
            foodBlocksQueue.Enqueue(block);
        }
        foreach (ItemVariant variant in foodVariants)
        {
            if (foodBlocksQueue.Count > 0)
            {
                foodBlocksQueue.Dequeue().TryGetComponent<Item>(out Item foodBlock);
                if (foodBlock != null)
                {
                    foodBlock.id = variant.foodID;
                    foodBlock.SetItemName(variant.foodName);
                    foodBlock.SetItemImage(variant.foodImage);
                    foodBlock.SetItemPrice(variant.price);
                    foodBlock.SetItemDescriptionText(variant.descriptionText);
                    foodBlock.SetItemSpecialType(variant.specialTypeSprite);
                }
            }
        }
    }

    public void AddToCart(ItemVariant item)   // add item to cart
    {
        if(itemsInCart.Contains(item))
        {
            var cleanItemsInCart = itemsInCart.OrderBy(x => item.foodID).ToList();
            item.foodAmount = cleanItemsInCart.Count().ToString();
        }
        else
        {
            itemsInCart.Add(item);
        }
    }
    public void RemoveFromCart(ItemVariant item)
    {
        if (itemsInCart.Contains(item))
        {
            var cleanItemsInCart = itemsInCart.OrderBy(x => item.foodID).ToList();
            if (cleanItemsInCart.Count() > 0)
            {
                item.foodAmount = (int.Parse(item.foodAmount) - 1).ToString();
            }
            else {
                itemsInCart.Remove(item);            // remove item from cart
            }
        }
    }
    public void InstanciateAllItemsInCart()   
    {
        Queue<GameObject> cartBlocksQueue = new Queue<GameObject>();  // Queue for handaling filling
        foreach (var block in cartBlocks)
        {
            cartBlocksQueue.Enqueue(block);
        }
        foreach (ItemVariant item in itemsInCart)
        {
            if (cartBlocksQueue.Count > 0)
            {
                cartBlocksQueue.Dequeue().TryGetComponent<Item>(out Item cartBlock);
                if (cartBlock != null)
                {
                    cartBlock.id = item.foodID;
                    cartBlock.SetItemName(item.foodName);
                    cartBlock.SetItemImage(item.foodImage);
                    cartBlock.SetItemPrice(item.price);
                    cartBlock.SetItemDescriptionText(item.descriptionText);
                    cartBlock.SetItemSpecialType(item.specialTypeSprite);
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
