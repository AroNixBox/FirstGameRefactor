using UnityEngine;

namespace UI {
    public class MainMenu : MonoBehaviour {
        // SceneReferences are draggable in the inspector by using:
        // https://assetstore.unity.com/packages/tools/utilities/scene-field-attach-scenes-to-inspector-free-223368?srsltid=AfmBOoq-fIlsJO1iPRIxoQ_8gs5bbmzhX3n7WBkTbtor4pYTpLiJRy-V
        [SerializeField] private Udar.SceneManager.SceneField menuScene;
        [SerializeField] private Udar.SceneManager.SceneField gameScene;
        [SerializeField] private Udar.SceneManager.SceneField tutorialScene;
    
        public void PlayGame() {
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene.Name);
        }
        public void QuitGame () {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE  
        Application.Quit();
#endif
        }
        public void GameMainMenu () {
            UnityEngine.SceneManagement.SceneManager.LoadScene(menuScene.Name);
        }
        public void PlayTutorial() {
            UnityEngine.SceneManagement.SceneManager.LoadScene(tutorialScene.Name);
        }
    }
}
