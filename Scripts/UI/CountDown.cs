using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    //for GameOverScreen
    //public GameObject objectToActivateAndDeactivate;
    //for timer
    float currentTime = 0f;
    float startingTime = 250f;

    [SerializeField] TMP_Text countdownText;

    public GameObject youLost;

    public float CurrentTime
    {
        get => currentTime; set => currentTime = value;
    }
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");

        if (currentTime <= 80)
        {
            countdownText.color = Color.yellow;
        }

        if (currentTime <= 30)
        {
            countdownText.color = Color.red;
        }
        else
        {
            countdownText.color = Color.white;
        }

        if (currentTime <= 0)
        {
            youLost.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
