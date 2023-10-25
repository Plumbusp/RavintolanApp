using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHandler : MonoBehaviour
{
    [SerializeField] private List<ItemVariant> foodVariants = new List<ItemVariant>();
    [SerializeField] private List<GameObject> foodBlocksList = new List<GameObject>();
    private Queue<GameObject> foodBlocks = new Queue<GameObject>();
    private void Awake()
    {
        foreach(var block in foodBlocksList)
        {
            foodBlocks.Enqueue(block);
        }
        foreach(ItemVariant variant in foodVariants)
        {
            if(foodBlocks.Count > 0)
            {
                foodBlocks.Dequeue().TryGetComponent<Item>(out Item foodBlock);
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
}
