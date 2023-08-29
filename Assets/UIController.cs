using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private VisualElement Container_PopUp;
    private VisualElement Scrim_PopUp;
    private VisualElement Window_PopUp;
    private VisualElement Button_Open_PopUp;
    private VisualElement Button_Close_PopUp;
    private VisualElement Button_Open_Shop;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Container_PopUp = root.Q("Container_PopUp");
        Scrim_PopUp = root.Q("Scrim_PopUp");
        Window_PopUp = root.Q("Window_PopUp");
        Button_Open_PopUp = root.Q("Button_OpenPopUp");
        Button_Close_PopUp = root.Q("Button_ClosePopUp");

        Button_Open_PopUp.RegisterCallback<ClickEvent>(OnOpenPopUpButtonClicked);
        Button_Close_PopUp.RegisterCallback<ClickEvent>(OnClosePopUpButtonClicked);
    }  

    private void OnOpenPopUpButtonClicked(ClickEvent ev)
    {
        Container_PopUp.style.display = DisplayStyle.Flex;
        Window_PopUp.AddToClassList("popUpWindow-up");
        Scrim_PopUp.AddToClassList("scrim-fadedIn");

    }
    private void OnClosePopUpButtonClicked(ClickEvent ev)
    {
        Container_PopUp.style.display = DisplayStyle.None;
        Window_PopUp.RemoveFromClassList("popUpWindow-up");
        Scrim_PopUp.RemoveFromClassList("scrim-fadedIn");
    }
}
