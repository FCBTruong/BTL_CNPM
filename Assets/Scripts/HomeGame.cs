using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeGame : MonoBehaviour
{
    public static int gameKind; // 0 is forward, 1 is backward
    private void Start()
    {
        gameKind = 0;
        DontDestroyOnLoad(this);
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
}
