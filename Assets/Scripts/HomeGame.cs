using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeGame : MonoBehaviour
{
    public static int gameKind; // 0 is forward, 1 is backward
    public static HomeGame Instance;
    private void Start()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
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
