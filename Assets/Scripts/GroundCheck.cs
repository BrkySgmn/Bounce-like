using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Ball ball;
    private void Awake()
    {
        ball = GetComponent<Ball>();
    }
    //checks the ball if it is on ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ball.OnGround = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            GameEvents.current.PlayerHit();  
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            ball.OnGround = false;
    }
}
