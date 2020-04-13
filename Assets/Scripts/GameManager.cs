using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private int numberBallMiss;
    public GameObject gameOver;
    public List<Ball> listBalls = new List<Ball>();

    public bool gameOverStatus;
    public static float distanceBall;
    public Transform endBall;

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
            Invoke("ShowWinGame", 2.0f);
        }
        else
            Ruler.Instance.RefreshRuler();
    }

    public void ShowWinGame()
    {
        gameOver.SetActive(true);
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void MoveBallLeft()
    {
        if (numberBallMiss == 5) return;
        listBalls[numberBallMiss].MoveLeft();
        numberBallMiss++;
    }
}
