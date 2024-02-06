using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ShopCategoryButton : MonoBehaviour
{
    public event Action Click;
    [SerializeField] private Color _unselectedColor;
    [SerializeField] private Color _selectedColor;
    private Image _image;
    private Button _button;
    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }
    private void OnClick() => Click?.Invoke();
    public void Selected() => _image.color = _selectedColor;
    public void UnSelected() => _image.color = _unselectedColor;
}
