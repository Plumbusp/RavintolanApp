using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private VisualElement Container1;
    private VisualElement Container1_PopUp;
    private VisualElement Scrim_PopUp;
    private VisualElement Window_PopUp;
    private VisualElement Button_OpenPopUp;
    private VisualElement Button_ClosePopUp;
    private VisualElement Button_OpenShop;
    private VisualElement Container2;
    private List<VisualElement> ButtonS_AddToCart = new List<VisualElement>();


    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Container1= root.Query("Container1");
        Container1_PopUp = root.Q("Container1_PopUp");
        Scrim_PopUp = root.Q("Scrim_PopUp");
        Window_PopUp = root.Q("Window_PopUp");
        Button_OpenPopUp = root.Q("Button_OpenPopUp");
        Button_ClosePopUp = root.Q("Button_ClosePopUp");
        Button_OpenShop = root.Query("Button_OpenShop").First();
        Container2 = root.Q("Container2");
        ButtonS_AddToCart = root.Query("Button_OpenShop").ToList();

        Button_OpenPopUp.RegisterCallback<ClickEvent>(OnOpenPopUpButtonClicked);
        Button_ClosePopUp.RegisterCallback<ClickEvent>(OnClosePopUpButtonClicked);
        Button_OpenShop.RegisterCallback<ClickEvent>(OnOpenShopButtonClicked);

        foreach (VisualElement button in ButtonS_AddToCart)
        {
            button.RegisterCallback<ClickEvent>(OnAddToCartClicked);
        }
    }  

    private void OnOpenPopUpButtonClicked(ClickEvent ev)
    {
        Container1_PopUp.style.display = DisplayStyle.Flex;
        Window_PopUp.AddToClassList("popUpWindow-up");
        Scrim_PopUp.AddToClassList("scrim-fadedIn");

    }
    private void OnClosePopUpButtonClicked(ClickEvent ev)
    {
        Container1_PopUp.style.display = DisplayStyle.None;
        Window_PopUp.RemoveFromClassList("popUpWindow-up");
        Scrim_PopUp.RemoveFromClassList("scrim-fadedIn");
    }
    private void OnOpenShopButtonClicked(ClickEvent ev)
    {
        Container1.style.display = DisplayStyle.None;
        Container2.style.display = DisplayStyle.Flex;
    }
    private void OnAddToCartClicked(ClickEvent ev)
    {

    }
}
