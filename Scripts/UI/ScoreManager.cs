using TMPro;
using UnityEngine;

namespace UI {
    public class ScoreManager : MonoBehaviour {
        // A better way would be a UI Event Channel
        public static ScoreManager Instance;

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highscoreText;

        // Score that counts the enemies killed
        private int _score;
        private int _highscore;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        private void Start() {
            // Load the highscore from the PlayerPrefs
            _highscore = PlayerPrefs.GetInt("highscore", 0);
        
            scoreText.text = _score + " POINTS";
            highscoreText.text = "HIGHSCORE: " + _highscore;
        }
    
        public void AddPoint () {
            _score ++;
            
            // Display the score
            scoreText.text = _score + " POINTS";
            // If highscore, update the highscore
            if (_highscore < _score) {
                PlayerPrefs.SetInt("highscore", _score);
            }
        }
    }
}
