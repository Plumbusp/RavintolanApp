using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New food variant", menuName = "Food/New Food Variant")]
public class FoodVariant : ScriptableObject
{
    public int foodID;
    public string foodName;
    public Sprite foodImage;
    public float price;
    public string descriptionText;
    public Sprite specialTypeSprite;
}
