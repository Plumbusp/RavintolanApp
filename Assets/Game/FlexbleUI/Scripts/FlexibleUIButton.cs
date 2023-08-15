using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FlexibleUIButton : BaseClass
{
    Button button;
    Image image;
   
    protected override void UISkinUpdater()
    {
        base.UISkinUpdater();

        button = GetComponent<Button>();
        image = GetComponent<Image>();
        
        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.sprite;
        image.color = skinData.generalColor;

    }

}
