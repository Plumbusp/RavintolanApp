using System;
using UnityEngine;
using UnityEngine.UI;

public class ThankYouPanelController : MonoBehaviour
{
    public static event Action OnNextStep;
    [SerializeField] private Button _returnButton;
    private void Awake()
    {
        _returnButton.onClick.AddListener(delegate { OnNextStep?.Invoke();  gameObject.SetActive(false); });
    }
}