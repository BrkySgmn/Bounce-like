using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Ball ball;
    private void Start()
    {
        ball = GetComponent<Ball>();
    }
    public void OnLeftDown()
    {
        ball.rollLeft = true;
    }
    public void OnLeftUp()
    {
        ball.rollLeft = false;
    }
    public void OnRightDown()
    {
        ball.rollRight = true;
    }
    public void OnRightUp()
    {
        ball.rollRight = false;
    }
    public void OnJumpDown()
    {
        ball.OnJumpDown();
    }
    public void OnJumpUp()
    {
        ball.OnJumpUp();
    }
}
