using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        numberBallMiss -= score;
        if (score > 0) listBalls[numberBallMiss].MoveRight();
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
}
