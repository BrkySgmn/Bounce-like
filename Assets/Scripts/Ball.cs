using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] float velocityLimit;

    [Range(0f, 25f)]
    [SerializeField] float ballRollSpeed = 5f;

    [Range(0f, 10f)]
    [SerializeField] float ballJumpForce = 1f;

    [SerializeField] float jumpTimeCounter;

    Rigidbody2D ball;

    Timer timer;

    float axis;

    float timeMultiple;

    public bool rollRight { get; set; }

    public bool rollLeft { get; set; }

    private bool onGround;

    public bool OnGround { get => onGround; set => onGround = value; }

    void Start()
    {
        timer = GetComponent<Timer>();
        ball = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        axis = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        // with onGround, ball can not jump or move while ball is on air
        if (onGround)
        {
            Roll();
            if (rollLeft)
            {
                RollLeft();
                if (ball.velocity.x > 0)
                {
                    ball.AddForce(new Vector2(-0.2f * ballRollSpeed,
        ball.velocity.y));
                }
            }
            if (rollRight)
            {
                RollRight();
                if (ball.velocity.x < 0)
                {
                    ball.AddForce(new Vector2(0.2f * ballRollSpeed,
        ball.velocity.y));
                }
            }
            if (ball.velocity.x < 0)
            {
                ball.AddForce(new Vector2(0.2f * ballRollSpeed,
    ball.velocity.y));
            }
            if (ball.velocity.x > 0)
            {
                ball.AddForce(new Vector2(-0.2f * ballRollSpeed,
    ball.velocity.y));
            }
            SetSpeedLimit();
        }
    }
    void SetSpeedLimit()
    {
        if (ball.velocity.x > velocityLimit)
            ball.velocity = new Vector2(velocityLimit, ball.velocity.y);
        if (ball.velocity.x < -velocityLimit)
            ball.velocity = new Vector2(-velocityLimit, ball.velocity.y);
    }
    void RollLeft()
    {
        ball.AddForce(new Vector2(-1 * ballRollSpeed,
        ball.velocity.y));
    }
    void RollRight()
    {
        ball.AddForce(new Vector2(1 * ballRollSpeed,
            ball.velocity.y));
    }
    void Roll()
    {
        ball.AddForce(new Vector2(axis * ballRollSpeed,
            ball.velocity.y), ForceMode2D.Force);
    }
    void Jump()
    {
        if (jumpTimeCounter <= timer.holdTime)
        {
            timeMultiple = 1.5f;
        }
        else
        {
            timeMultiple = timer.holdTime + 1;
        }
        ball.velocity = new Vector2(ball.velocity.x, ballJumpForce * timeMultiple);
    }
    public void OnJumpDown()
    {
        if (onGround)
        {
            timer.StartTimer();
        }
    }
    public void OnJumpUp()
    {
        if (onGround)
        {
            timer.StopTimer();
            Jump();
            timer.ResetTimer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trig"))
        {
            transform.position = new Vector3(-7.46f, 0.45f, 0);
        }
    }
}
