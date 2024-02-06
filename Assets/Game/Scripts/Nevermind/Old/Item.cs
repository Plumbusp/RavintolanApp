using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Xml.Serialization;

public class Item : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button addButton;
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text priceField;
    [SerializeField] private TMP_Text foodAmount;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private Button descriptionButton;
    [SerializeField] private GameObject specialTag;
    [HideInInspector] public int id { get; set; }

    public delegate void AddingItem(int id);
    public static event AddingItem OnItemAdded;
    private void OnEnable()
    {
        addButton.onClick.AddListener(() => OnItemAdded?.Invoke(id));
        descriptionButton.onClick.AddListener(HandleDescriptionPressed);
    }
    private void OnDisable()
    {
        addButton.onClick.RemoveAllListeners();
    }
    public void SetItemPrice(float price) => this.priceField.text = price.ToString();
    public void SetItemName(string name) => nameField.text = name;
    public void SetItemImage(Sprite sprite) => image.sprite = sprite;
    public void SetFoodAmount(int amount) => foodAmount.text = amount.ToString();
    public void SetItemDescriptionText(string text) => descriptionPanel.GetComponentInChildren<TMP_Text>().text = text;
    public void SetItemSpecialType(Sprite typeSprite) => specialTag.GetComponent<Image>().sprite = typeSprite;

    private void HandleDescriptionPressed()
    {
        if (descriptionPanel.activeSelf)
        {
            descriptionPanel.SetActive(false);
            descriptionButton.GetComponent<ButtonExtras>().buttonText.text = "Description";
        }
        else
        {
            descriptionPanel.SetActive(true);
            descriptionButton.GetComponent<ButtonExtras>().buttonText.text = "Return";
        }
    }
}
