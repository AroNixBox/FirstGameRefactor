using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void GameMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RetryGame ()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
