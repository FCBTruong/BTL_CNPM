﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private int numberBallMiss;
    public GameObject gameOver;
    public List<Ball> listBalls = new List<Ball>();

    public bool gameOverStatus;
    public static float distanceBall;
    public Transform endBall;

    // Change Language
    public Text backText;
    public Text titleText;
    public Text congratulation;

    public GameObject startButton;
    private void Start()
    {
        numberBallMiss = listBalls.Count;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        distanceBall = endBall.position.x - listBalls[listBalls.Count - 1].transform.position.x;
    }

    public void NextLevel(int score)
    {
        if (score > 0)
        {
            numberBallMiss -= score;
            listBalls[numberBallMiss].MoveRight();
        }
        if (numberBallMiss == 0)
        {
            gameOverStatus = true;
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayWinSound();
            }
            Invoke("ShowWinGame", 2.0f);
        }
        else
            Ruler.Instance.RefreshRuler();
    }

    public void ShowWinGame()
    {
        gameOver.SetActive(true);
        if(HomeGame.Instance != null) DestroyImmediate(HomeGame.Instance.gameObject);
    }

    public void BackHome()
    {
        if (HomeGame.Instance != null)  DestroyImmediate(HomeGame.Instance.gameObject);
        SceneManager.LoadScene("Home");
    }

    public void MoveBallLeft()
    {
        if (numberBallMiss == 5) return;
        listBalls[numberBallMiss].MoveLeft();
        numberBallMiss++;

        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayLoseSound();
        }
    }

    public void ChangLanguage()
    {
        int language = 0;
        if (DataManager.Instance != null)
            language = DataManager.Instance.language;
        if (language == 0)
        {
            ChangeLanguageToVietnamese();
        }
        else
        {
            ChangeLanguageToEnglish();
        }
    }

    public void ChangeLanguageToEnglish()
    {
        backText.text = "Back";
        titleText.text = "Fill in the blanks on the number line";
        congratulation.text = "Well done! You completed the card";
        PlayerPrefs.SetInt("Language", 0);
        if(DataManager.Instance != null) DataManager.Instance.language = 0;
    }

    public void ChangeLanguageToVietnamese()
    {
        backText.text = "Trở lại";
        titleText.text = "Điền vào các ô trống số phù hợp";
        congratulation.text = "Làm tốt lắm! Bạn đã hoàn thành bài tập";
        PlayerPrefs.SetInt("Language", 1);
        if (DataManager.Instance != null) DataManager.Instance.language = 1;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }
}
