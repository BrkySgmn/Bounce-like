using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Player.healthCount = 3;
    }
}
