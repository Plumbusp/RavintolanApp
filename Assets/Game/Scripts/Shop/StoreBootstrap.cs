using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoreBootstrap : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Cart _cart;
    [SerializeField] private ConformationController _personalInfoController;

    private PersistantData _persistantData;
    private LocalDataProvider _localDataProvider;
    private void Awake()
    {
        InitializeData();
        _shop.Initialize(_persistantData);
        _cart.Initialize(_persistantData, _localDataProvider);
        _personalInfoController.Initialize(_persistantData);
        ThankYouPanelController.OnNextStep += RestartData;
    }
    private void OnDestroy()
    {
        ThankYouPanelController.OnNextStep -= RestartData;
    }
    private void InitializeData()
    {
        _persistantData = new PersistantData();
        _persistantData.OrderDataObject = new DataObject();
        _localDataProvider = new LocalDataProvider(_persistantData);
        _localDataProvider.TryLoadCount();
    }
    private void RestartData()
    {
        _persistantData.OrderDataObject = new DataObject();
        Debug.Log("Restaer Data");
    }
}
