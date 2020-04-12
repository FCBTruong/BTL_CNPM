using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public Text titleGame;
    public Text back;

    public void ChangeLanguageToEnglish()
    {
        titleGame.text = "Fill in the blanks on the number line";
        back.text = "Back";
    }

    public void ChangeLanguageVietnamese()
    {
        titleGame.text = "Điền vào chỗ trống giá trị phù hợp";
        back.text = "Trở lại";       
    }
}
