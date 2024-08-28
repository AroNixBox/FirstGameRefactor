using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI {
    public class GameOver : MonoBehaviour {
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject youLost;

        private void Awake() {
            gameOver.SetActive(false);
            youLost.SetActive(false);
        }

        public async UniTaskVoid EndGame() {
            await UniTask.Delay(1000);
            EnableGameWonScreen();
            
            // Pause the game
            Time.timeScale = 0f;
        }
        public void EnableGameWonScreen() => gameOver.SetActive(true);
        public void EnableGameLostScreen() => youLost.SetActive(true);
    }
}
