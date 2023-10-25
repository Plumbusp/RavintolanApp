using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartBlockMono : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text amount;
    public void SetImage(Sprite sprite)=> image.sprite = sprite;
    public void SetName(string name)=> itemName.text = name;
    public void SetAmount(int amount) => this.amount.text = amount.ToString();
}
