using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI Skin Data", menuName = "UIBottonSkinData")]
public class UIBottonSkinData : ScriptableObject
{
    public Color generalColor;
    public Sprite sprite;
    public SpriteState buttonSpriteState;
}
