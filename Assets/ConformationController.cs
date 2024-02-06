using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConformationController : MonoBehaviour
{
    public static event Action OnNextStep;
    [SerializeField] private Button _nextStepButton;
    [SerializeField] private TMP_Text _finalSumText;
    private PersistantData _persistantData;
    private void Awake()
    {
        _nextStepButton.onClick.AddListener(delegate { OnNextStep?.Invoke(); });
    }
    private void OnEnable()
    {
        _finalSumText.text = "Final sum of the order: " + _persistantData.OrderDataObject.GetOrderSum().ToString() + "€";
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
