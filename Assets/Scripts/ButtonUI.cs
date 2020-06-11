using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    void Start()
    {
        Enable();
        GameEvents.current.onGamePause += Disable;
        GameEvents.current.onGameOver += Disable;
        GameEvents.current.onGameContinue += Enable;
        GameEvents.current.onPlayerHit += Player.DecreaseHealth;
        GameEvents.current.onPlayerHit += UpdateText;
        UpdateText();
    }

    private void UpdateText()
    {
        GetComponentInChildren<Text>().text = "x" + Player.healthCount.ToString();
    }

    void Enable()
    {
        gameObject.SetActive(true);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        GameEvents.current.onGamePause -= Disable;
        GameEvents.current.onGameOver -= Disable;
        GameEvents.current.onGameContinue -= Enable;
        GameEvents.current.onPlayerHit -= Player.DecreaseHealth;
        GameEvents.current.onPlayerHit -= UpdateText;
    }
}
