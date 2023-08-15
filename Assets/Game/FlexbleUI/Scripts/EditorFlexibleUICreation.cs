using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorFlexibleUICreation : Editor
{
    static GameObject clickedObject;
    [MenuItem("GameObject/Flexible UI/Button", priority = 1)]
    public static void AddButton()
    {
        Create("Button", "Flexible UI/Button");
    }
    private static GameObject Create(string objectName, string path)
    {

        GameObject instance = Instantiate(Resources.Load<GameObject>(path));
        instance.name = objectName;
        clickedObject = UnityEditor.Selection.activeObject as GameObject;
        if(clickedObject != null)
        {
            instance.transform.SetParent(clickedObject.transform, false);
        }
        return instance;
    }
}
