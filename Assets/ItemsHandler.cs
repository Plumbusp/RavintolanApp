using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHandler : MonoBehaviour
{
    [SerializeField] private List<FoodVariant> foodVariants = new List<FoodVariant>();
    [SerializeField] private List<GameObject> foodBlocksList = new List<GameObject>();
    private Queue<GameObject> foodBlocks = new Queue<GameObject>();
    private void Awake()
    {
        foreach(var block in foodBlocksList)
        {
            foodBlocks.Enqueue(block);
        }
        foreach(FoodVariant variant in foodVariants)
        {
            if(foodBlocks.Count > 0)
            {
                foodBlocks.Dequeue().TryGetComponent<FoodBlock>(out FoodBlock foodBlock);
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
    private void OnEnable()
    {
        FoodBlock.OnAddToCart += BuyFood;
    }
    private void OnDisable()
    {
        FoodBlock.OnAddToCart -= BuyFood;
    }
    private void BuyFood(int foodID)
    {

    }
}
