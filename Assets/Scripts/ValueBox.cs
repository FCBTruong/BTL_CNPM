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

    public GameObject inputNumber3Char;
    public GameObject inputNumber2Char;
    public GameObject inputNumber1Char;

    public Text char1;
    public Text char2;
    public Text char3;

    public Text twoChar1;
    public Text twoChar2;

    public Text oneChar;

    public List<Text> listChar = new List<Text>();

    private int firstChar;
    private int checkCharIndex = 0;

    private string valueString;
    public Animator anim;

    private int boxKind;
    private bool choosing;
    private void Awake()
    {
        //anim = this.GetComponent<Animator>();
        inputNumber3Char.SetActive(false);
        inputNumber2Char.SetActive(false);
        inputNumber1Char.SetActive(false);
    }
    public void Refresh()
    {
        inputNumber1Char.GetComponent<Image>().color = Color.white;
        inputNumber2Char.GetComponent<Image>().color = Color.white;
        inputNumber3Char.GetComponent<Image>().color = Color.white;
        inputNumber3Char.SetActive(false);
        inputNumber2Char.SetActive(false);
        inputNumber1Char.SetActive(false);

        listChar = new List<Text>();

        valueText.fontStyle = FontStyle.Normal;

        char1.text = "";
        char2.text = "";
        char3.text = "";

        twoChar1.text = "";
        twoChar2.text = "";

        oneChar.text = "";
        checkCharIndex = 0;

        anim.Rebind();
        choosing = false;
    }
    private void SpecializeNumber()
    {
        valueText.fontStyle = FontStyle.Bold;
    }

    public void SetNumber(int value)
    {
        this.value = value;
        valueString = value.ToString("");

        CreateListChar(value);
        if (value >= 100)
        {
            firstChar = value / 100;         
        }
        else if (value < 10)
        {
            firstChar = value;
        }
        else
        {
            firstChar = value / 10;
        }

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
        if (value >= 100)
        {
            inputNumber3Char.SetActive(true);
            boxKind = 3;
        }
        else if (value >= 10)
        {
            inputNumber2Char.SetActive(true);
            boxKind = 2;
        }
        else
        {
            inputNumber1Char.SetActive(true);
            boxKind = 1;
        }
        valueText.enabled = false;
    }

    public bool InputNumber()
    {

        choosingStatus();

        if (Input.GetKeyDown(KeyCode.Alpha0) || KeyboardScript.numberInput == 0)
        {
            return CheckInputNumber(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || KeyboardScript.numberInput == 1)
        {
            return CheckInputNumber(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || KeyboardScript.numberInput == 2)
        {
            return CheckInputNumber(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || KeyboardScript.numberInput == 3)
        {
            return CheckInputNumber(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || KeyboardScript.numberInput == 4)
        {
            return CheckInputNumber(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || KeyboardScript.numberInput == 5)
        {
            return CheckInputNumber(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || KeyboardScript.numberInput == 6)
        {
            return CheckInputNumber(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) || KeyboardScript.numberInput == 7)
        {
            return CheckInputNumber(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) || KeyboardScript.numberInput == 8)
        {
            return CheckInputNumber(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) || KeyboardScript.numberInput == 9)
        {
            return CheckInputNumber(9);
        }

        return false;
    }

    private void choosingStatus()
    {
        if (choosing == true) return;
        choosing = true;
        switch (boxKind)
        {
            case 1:
                inputNumber1Char.GetComponent<Image>().color = Color.cyan;
                break;
            case 2:
                inputNumber2Char.GetComponent<Image>().color = Color.cyan;
                break;
            case 3:
                inputNumber3Char.GetComponent<Image>().color = Color.cyan;
                break;
        }
    }
    public bool CheckInputNumber(int x)
    {
        KeyboardScript.numberInput = -1;
        Debug.Log(listChar.Count);
        listChar[checkCharIndex].text = x.ToString("");
        if (x == firstChar)
        {
            listChar[checkCharIndex].color = Color.black;
            if (checkCharIndex == listChar.Count - 1)
            {
                if(value >= 100) inputNumber3Char.SetActive(false);
                else if(value >= 10) inputNumber2Char.SetActive(false);
                else inputNumber1Char.SetActive(false);
                valueText.enabled = true;
                return true;
            }
            Debug.Log(valueString);
       
            valueString = RemoveFirstChar(valueString);

            firstChar = valueString[0] - '0';
            Debug.Log("x" + firstChar);       
            checkCharIndex++;
        }
        else
        {
            listChar[checkCharIndex].color = Color.red;
            Ruler.score--;

            if(Ruler.score == -1)
            {
                GameManager.Instance.MoveBallLeft();
            }
        }
        return false;
    }

    public void CreateListChar(int num)
    {
       if(num >= 100)
        {
            listChar.Add(char1);
            listChar.Add(char2);
            listChar.Add(char3);
        }
       else if(num < 10)
        {
            listChar.Add(oneChar);
        }
        else
        {
            listChar.Add(twoChar1);
            listChar.Add(twoChar2);
        }
    }

    public string RemoveFirstChar(string s)
    {
        string x = "";
        for(int i = 1; i < s.Length; i++)
        {
            x += s[i];
        }
        return x;
    }

    public void ShowArrowRight()
    {
        anim.SetTrigger("ShowArrowRight");
    }
    public void ShowArrowLeft()
    {
        anim.SetTrigger("ShowArrowLeft");
    }
}
