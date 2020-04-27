using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{ 
    public GameObject RusLayoutSml, RusLayoutBig, EngLayoutSml, EngLayoutBig, SymbLayout;
    public static int numberInput = -1;

    public void alphabetFunction(string alphabet)
    {
        char x = alphabet[0];
        if( x >= '0' && '9' >= x)
        {
            numberInput = x - '0';
        }
    }

    public void BackSpace()
    {

    }

    public void CloseAllLayouts()
    {

        RusLayoutSml.SetActive(false);
        RusLayoutBig.SetActive(false);
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
    }

    public void ShowLayout(GameObject SetLayout)
    {
        CloseAllLayouts();
        EngLayoutSml.SetActive(true);
        EngLayoutBig.SetActive(true);
        SetLayout.SetActive(true);
    }

}
