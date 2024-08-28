using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject youLost;

    private void Awake()
    {
        gameOver.SetActive(false);
        youLost.SetActive(false);
    }
}
