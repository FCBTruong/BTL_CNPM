using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeGame : MonoBehaviour
{
    public static int gameKind; // 0 is forward, 1 is backward
    public static HomeGame Instance;

    // Text
    public Text titleGame;
    public Text titleLevelOne;
    public Text titleLevelTwo;

    private void Start()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
        gameKind = 0;
        DontDestroyOnLoad(this);

        if(DataManager.Instance != null)
        {
            if(DataManager.Instance.language == 1)
            {
                // If user changed language to Vietnamese
                ChangeLanguageToVietnamese();
            }
            // English is default
        }
    }

    public void PressGame1()
    {
        gameKind = 0;
        PlayGame();
    }

    public void PressGame2()
    {
        gameKind = 1;
        PlayGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void ChangeLanguageToVietnamese()
    {
        titleGame.text = "Đếm phía trước và phía sau. Cấp độ 1";
        titleLevelOne.text = "Đếm theo thứ tự tới 1000. Cấp độ 1";
        titleLevelTwo.text = "Đếm ngược tới 1000. Cấp độ 2";
    }
}
