using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CartManager;
using static FoodBlock;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button openCart;
    [SerializeField] private GameObject appetizers;
    [SerializeField] private GameObject cart;
    [SerializeField] private List<FoodVariant> foodVariants = new List<FoodVariant>();
    [SerializeField] private List<GameObject> foodBlocksList = new List<GameObject>();
    [SerializeField] private List<GameObject> cartBlocks = new List<GameObject>();
    GoodsManager goodsManager;
    CartManager cartManager;
    private void Awake()
    {
        goodsManager = new GoodsManager(foodVariants, foodBlocksList);
        goodsManager.CreateAllGoods();
        cartManager = new CartManager(cartBlocks);
        openCart.onClick.AddListener(() => HandleCartOpen());
        Item.OnItemAdded += HandleItemAdd;
        Item.OnItemRemoved += HandleItemRemove;
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
    private void HandleItemRemove(int id)
    {
        foreach (FoodVariant variant in foodVariants)
        {
            if (variant.foodID == id)
            {
                cartManager.RemoveFromCart(variant);
            }
        }
    }
    private void HandleCartOpen()
    {
        appetizers.SetActive(false);
        cart.SetActive(true);
        cartManager.InstanciateAllItemsInCart();
    }
}
