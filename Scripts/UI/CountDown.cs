using System;
using TMPro;
using UnityEngine;

namespace UI {
    public class CountDown : MonoBehaviour {
        [SerializeField] TMP_Text countdownText;
        [SerializeField] private float countdownSeconds = 250f;
        [SerializeField] private GameOver gameOver;
        
        private DateTime _endTime;
        private const float ColorYellowThreshold = 80f;
        private const float ColorRedThreshold = 30f;

        
        private void Start() {
            _endTime = DateTime.Now.AddSeconds(countdownSeconds);
        }
        
        private void Update() {
            var remainingTime = _endTime - DateTime.Now;
            countdownText.text = remainingTime.ToString(@"mm\:ss\.ff");

            countdownText.color = remainingTime.TotalSeconds switch {
                <= ColorRedThreshold => Color.red,
                <= ColorYellowThreshold => Color.yellow,
                _ => Color.white
            };

            if (remainingTime.TotalSeconds <= 0) {
                gameOver.EnableGameLostScreen();
                Time.timeScale = 0;
            }
        }
    }
}
