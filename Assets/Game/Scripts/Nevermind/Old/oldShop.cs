using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class oldShop : MonoBehaviour
{
    [SerializeField] private Button openShop;
    [SerializeField] private List<ItemVariant> foodVariants = new List<ItemVariant>();
    [SerializeField] private List<GameObject> foodBlocks = new List<GameObject>();
    [SerializeField] private List<GameObject> cartBlocks = new List<GameObject>();

    CartManager cartManager;
    private void Awake()
    {
        cartManager = new CartManager(foodVariants, foodBlocks, foodBlocks);
        openShop.onClick.AddListener(() => cartManager.InstanciateAllItemsInCart());
        Item.OnItemAdded += HandleItemAdd;
    }
    private void OnDisable()
    {
        Item.OnItemAdded -= HandleItemAdd;
    }

    private void HandleItemAdd(int id)
    {
        foreach (ItemVariant variant in foodVariants)
        {
            if(variant.foodID == id)
            {
                cartManager.AddToCart(variant);
            }
        }
    }
    private void HandleCartOpening()
    {
        cartManager.InstanciateAllItemsInCart();
    }
}
