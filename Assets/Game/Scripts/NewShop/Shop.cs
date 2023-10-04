using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static FoodBlock;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button openShop;
    [SerializeField] private List<FoodVariant> foodVariants = new List<FoodVariant>();
    [SerializeField] private List<GameObject> foodBlocksList = new List<GameObject>();
    [SerializeField] private List<GameObject> cartBlocks = new List<GameObject>();
    GoodsManager goodsManager;
    CartManager cartManager;
    private void Awake()
    {
        goodsManager = new GoodsManager(foodVariants, foodBlocksList);
        goodsManager.CreateAllGoods();
        cartManager = new CartManager();
        openShop.onClick.AddListener(() => cartManager.InstanciateAllItemsInCart());
        Item.OnItemAdded += HandleItemAdd;
    }
    private void OnDisable()
    {
        Item.OnItemAdded -= HandleItemAdd;
    }

    private void HandleItemAdd(int id)
    {
        foreach (FoodVariant variant in foodVariants)
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
