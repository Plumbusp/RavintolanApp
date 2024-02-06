using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    public static event Action OnNextStep;
    [SerializeField] private CartPanel _cartPanel;
    [SerializeField] private Button _buyButton;

    private PersistantData _persistantData;
    private LocalDataProvider _localDataProvider;
    private void Awake()
    {
        _buyButton.onClick.AddListener(delegate { PrepairOrder(); OnNextStep?.Invoke(); } );
        PersonalInfoController.OnNextStep += MakeOrder;
    }
    private void OnDestroy()
    {
        PersonalInfoController.OnNextStep -= MakeOrder;
    }
    public void Initialize(PersistantData persistantData, LocalDataProvider localDataProvider)
    {
        _persistantData = persistantData;
        _localDataProvider = localDataProvider;
    }
    public void Open()
    {
        gameObject.SetActive(true);
        if (_persistantData.OrderDataObject.ChoosedItems == null)
            return;
        _cartPanel.Show(_persistantData.OrderDataObject.ChoosedItems.ToList());
    }
    public void Close()
    {
        _cartPanel.Clear();
        gameObject.SetActive(false);
    }
    private void PrepairOrder() 
    {
        List<CartItem> itemsToBuy = new List<CartItem>();
        foreach(var itemView in _cartPanel.CartItems)
        {
            itemsToBuy.Add(itemView.Item);
        }  
        _persistantData.OrderDataObject.SetItemsToBuy(itemsToBuy);
    }
    private void MakeOrder()
    {
        _localDataProvider.Save();
        Debug.Log("Bought!");
    }
}

