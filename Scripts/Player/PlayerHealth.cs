using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider playerHealthBar;
    private float health = 0f;
    [SerializeField] private float keys = 0f;
    [SerializeField] private float maxHealth = 100f;

    public TMP_Text keyDisplay;

    //GameOver
    public GameObject gameOver;

    //YouLost
    public GameObject youLost;

    private void Start()
    {
        keys = 0f;
        health = maxHealth;
        KeyCollect();
    }
    private void Update()
    {
        playerHealthBar.value = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Player")
        {
            if (collision.tag == "Door" && keys >= 5f)
            {
                Destroy(collision.gameObject);
                StartCoroutine(GameIsEnding());
            }
            if (collision.tag == "Key")
            {
                keys += 1f;
                KeyCollect();
            }
        }
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Time.timeScale = 0f;
            youLost.SetActive(true);
        }
    }

    public void KeyCollect()
    {
        keyDisplay.text = "Keys: " + keys;
    }
    
    IEnumerator GameIsEnding ()
    {
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
