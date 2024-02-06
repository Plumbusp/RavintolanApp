using UnityEngine;

[CreateAssetMenu(fileName = "AppetizerItem", menuName = "Shop/Appetizer Item")]
public class AppetizerItem : ShopItem
{
    [field: SerializeField] public AppetizerTypes AppetizerType {  get; private set; }
}
