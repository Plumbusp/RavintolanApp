using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] List<Item> values = new List<Item>();
    Item[] items;
    public delegate void FinfingAllBlocks();
    public static event FinfingAllBlocks OnAllBlockesFound;
    private void OnEnable()
    {
        Item.OnItemAdded += AddItemToCart;
    }
    private void OnDisable()
    {
        
    }
    private void Start()
    {
        items = transform.Find("Blocks").GetComponentsInChildren<Item>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].id = values[i].id;
            items[i].added = values[i].added;
            items[i].itemName = values[i].itemName;
            items[i].specialTag = values[i].specialTag;
            items[i].price = values[i].price;
            items[i].itemDescription = values[i].itemDescription;
            items[i].picture = values[i].picture;
        }
    }
    private void AddItemToCart(int id)
    {
        foreach(Item item in items)
        {
            if(item.id == id)
            {
                Debug.Log("Added To cart " + item.name);
            }
        }
    }
}
