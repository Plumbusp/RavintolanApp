using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GoodsManager 
{
    List<FoodVariant> foodVariants;
    List<GameObject> foodBlocks;
    Queue<GameObject> foodBlocksQueue = new Queue<GameObject>();
    public GoodsManager(List<FoodVariant> foodVariants, List<GameObject> foodBlocksList)
    {
        this.foodVariants = new List<FoodVariant>(foodVariants);
        this.foodBlocks = new List<GameObject>(foodBlocksList);
    }
    public void CreateAllGoods()
    {
        foreach (var block in foodBlocks)
        {
            foodBlocksQueue.Enqueue(block);
        }
        foreach (FoodVariant variant in foodVariants)
        {
            if (foodBlocksQueue.Count > 0)
            {
                foodBlocksQueue.Dequeue().TryGetComponent<FoodBlock>(out FoodBlock foodBlock);
                if (foodBlock != null)
                {
                    foodBlock.foodID = variant.foodID;
                    foodBlock.SetItemName(variant.foodName);
                    foodBlock.SetItemImage(variant.foodImage);
                    foodBlock.SetItemPrice(variant.price);
                    foodBlock.SetItemDescriptionText(variant.descriptionText);
                    foodBlock.SetItemSpecialType(variant.specialTypeSprite);
                }
            }
        }
    }
}
