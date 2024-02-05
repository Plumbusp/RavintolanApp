using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PersonalInfoController : MonoBehaviour
{
    public static event Action OnNextStep;
    [SerializeField] private Button _nextStepButton;
    private PersistantData _persistantData;
    private void Awake()
    {
        _nextStepButton.onClick.AddListener(delegate { OnNextStep?.Invoke(); });
    }
    public void Initialize(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }
    public void SetUserName(string userName)
    {
        _persistantData.OrderDataObject.CustomerName = userName;
    }
    public void SetSpecialRequest(string specialRequest)
    {
        _persistantData.OrderDataObject.SpecialRequest = specialRequest;
    }
}
