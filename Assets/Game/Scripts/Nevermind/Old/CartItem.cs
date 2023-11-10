using UnityEngine;
using UnityEngine.UI;

public class CartItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private string itemName;
    [SerializeField] private string amount;
    public void SetImage(Sprite sprite)=> image.sprite = sprite;
    public void SetName(Sprite sprite)=> image.sprite = sprite;
    public void SetAmount(int amount) => this.amount = amount.ToString();
}
