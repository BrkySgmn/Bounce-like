using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    void Start()
    {
        Disable();
        GameEvents.current.onGamePause += Enable;
        GameEvents.current.onGameContinue += Disable;
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
        GameEvents.current.onGameContinue -= Enable;
    }
}
