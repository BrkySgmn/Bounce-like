using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
        Time.timeScale = 1f;
    }
    public event Action onPlayerHit;
    public void PlayerHit()
    {
        if (onPlayerHit != null)
        {
            onPlayerHit();
            if (Player.healthCount == 0)
                GameOver();
        }
    }
    public event Action onGamePause;
    public void PauseGame()
    {
        if(onGamePause!=null)
        {
            onGamePause();
            Time.timeScale = 0f;
        }
    }
    public event Action onGameContinue;
    public void ContinueGame()
    {
        if(onGameContinue!=null)
        {
            onGameContinue();
            Time.timeScale = 1f;
        }
    }
    public event Action onGameOver;

    public void GameOver()
    {
        if(onGameOver != null)
        {
            onGameOver();
            Time.timeScale = 0f;
        }
    }
}
