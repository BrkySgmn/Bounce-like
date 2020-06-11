using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        Disable();
        GameEvents.current.onGameOver += Enable;
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
        GameEvents.current.onGameOver -= Enable;
    }
}
