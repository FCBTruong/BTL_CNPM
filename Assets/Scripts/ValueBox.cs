using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBox : MonoBehaviour
{
    private int value;
    public GameObject normalLine;
    public GameObject boldLine;
    public Text valueText;
    public GameObject inputNumber;

    public Text char1;
    public Text char2;
    public Text char3;

    private void Awake()
    {
        inputNumber.SetActive(false);
    }
    private void SpecializeNumber()
    {
        valueText.fontStyle = FontStyle.Bold;
    }

    public void SetNumber(int value)
    {
        this.value = value;
        valueText.text = value.ToString("");
        if(value % 5 == 0)
        {
            SpecializeNumber();
            boldLine.SetActive(true);
            normalLine.SetActive(false);
        }
        else
        {
            boldLine.SetActive(false);
            normalLine.SetActive(true);
        }
    }

    public void HideNumber()
    {

    }

    public void SetInputStatus()
    {
        inputNumber.SetActive(true);
    }
}
