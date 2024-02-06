using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NewShop : MonoBehaviour
{
  [SerializeField] List<ItemValues> items = new List<ItemValues>();
    public VisualElement itemRepresentation;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var scrollAreaContent = root.Q("Container2").Q("Content");
        VisualElement itemRepresentation = root.Q("item");
        
        foreach (ItemValues item in items)
        {
            scrollAreaContent.Add(itemRepresentation);
        }
    }

}
