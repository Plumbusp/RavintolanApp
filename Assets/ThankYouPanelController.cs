using System;
using UnityEngine;
using UnityEngine.UI;

public class ThankYouPanelController : MonoBehaviour
{
    [SerializeField] private Button _returnButton;
    private void Awake()
    {
        _returnButton.onClick.AddListener(delegate { gameObject.SetActive(false); });
    }
}