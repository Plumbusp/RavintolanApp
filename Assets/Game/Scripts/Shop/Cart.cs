using System;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    public event Action OnOrderMade;
    [SerializeField] private CartPanel _cartPanel;
    [SerializeField] private Button _buyButton;

    private PersistantData _persistantData;
    private LocalDataProvider _localDataProvider;
    private void OnEnable()
    {
        _buyButton.onClick.AddListener(MakeOrder);
    }
    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(MakeOrder);
    }
    public void Initialize(PersistantData persistantData, LocalDataProvider localDataProvider)
    {
        _persistantData = persistantData;
        _localDataProvider = localDataProvider;
    }
    public void Open()
    {
        if (_persistantData.OrderDataObject.ChoosedItems == null)
            return;
        _cartPanel.Show(_persistantData.OrderDataObject.ChoosedItems);
    }
    public void Close()
    {
        _cartPanel.Clear();
    }
    private void MakeOrder() // Or buy with different make order
    {
        _localDataProvider.Save();
        Debug.Log("Bought!");
        OnOrderMade?.Invoke();
    }
}
