using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 positionInitial;
    private Vector2 positionDestination;
    private bool move;
    private float speed = 4.0f;

    private void Start()
    {
        positionInitial = this.transform.position;
    }

    private void Update()
    {
        if (move)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, positionDestination, speed * Time.deltaTime);
            if(System.Math.Abs(this.transform.position.x - positionDestination.x) < 0.0000005f)
            {
                this.transform.position = positionDestination;
                move = false;
            }
        }
    }
    public void MoveLeft()
    {
        positionDestination = new Vector2(positionInitial.x, positionInitial.y);
        move = true;
    }

    public void MoveRight()
    {
        positionDestination = new Vector2(positionInitial.x + GameManager.distanceBall, positionInitial.y);
        move = true;
    }
}
