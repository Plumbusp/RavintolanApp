using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueView<T> : MonoBehaviour where T : IConvertible
{
    [SerializeField] private TMP_Text text;
    public void Show(T value)
    {
        gameObject.SetActive(true);
        text.text = value.ToString();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
