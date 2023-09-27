using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Xml.Serialization;

public class FoodBlock : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button addButton; 
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text priceField;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private Button descriptionButton;
    [SerializeField] private GameObject specialTypePanel;
    [HideInInspector] public int foodID { get; set; }

    public delegate void ForAddToCart(int ID);
    public static event ForAddToCart OnAddToCart;
    private void OnEnable()
    {
        addButton.onClick.AddListener(() => OnAddToCart?.Invoke(foodID));
        descriptionButton.onClick.AddListener(HandleDescriptionPressed);
    }
    private void OnDisable()
    {
        addButton.onClick.RemoveAllListeners();
    }
    public void SetItemPrice(float price) => this.priceField.text = price.ToString();
    public void SetItemName(string name) => nameField.text = name;
    public void SetItemImage(Sprite sprite) => image.sprite = sprite;
    public void SetItemDescriptionText(string text) =>  descriptionPanel.GetComponentInChildren<TMP_Text>().text = text;
    public void SetItemSpecialType(Sprite typeSprite) => specialTypePanel.GetComponent<Image>().sprite = typeSprite;

    private void HandleDescriptionPressed()
    {
        if(descriptionPanel.activeSelf)
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
