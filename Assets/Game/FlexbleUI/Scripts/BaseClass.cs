using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BaseClass : MonoBehaviour
{

    public UIBottonSkinData skinData;
    // Start is called before the first frame update
    void Awake()
    {
        UISkinUpdater();
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isEditor)
        {
            UISkinUpdater();
        }
    }

    protected virtual void UISkinUpdater()
    {

    }
}
