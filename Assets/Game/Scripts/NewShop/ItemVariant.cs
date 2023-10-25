using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New food variant", menuName = "Food/New Food Variant")]
public class ItemVariant : ScriptableObject
{
    public int foodID;
    public string foodName;
    public Sprite foodImage;
    public string foodAmount;
    public float price;
    public string descriptionText;
    public Sprite specialTypeSprite;
}
