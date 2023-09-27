using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[System.Serializable]
public class Item: MonoBehaviour, IItem
{
    public delegate void AddingItem(int id);
    public static event AddingItem OnItemAdded;
    public int id;
    public bool added;
    public string itemName;
    public string specialTag;
    public float price;
    public string itemDescription;
    public Sprite picture;
    private Image image;
    private Button buttonAdd;
    private void Awake()
    {
        image.sprite = picture;
        buttonAdd.clicked += () => OnItemAdded.Invoke(id);
    }
}
