using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private const int TotalEnemies = 16;

    public GameObject VictoryText;
    public GameObject DefeatText;
    public GameObject RestartButton;

    public int enemiesleft;

    private bool m_isGameOver;

    public bool isGameOver
    {
        get { return m_isGameOver;  }
        set
        {
            m_isGameOver = value;
            if (value)
            {
                //Game Over Screen setup
                VictoryText.SetActive(playerWon);
                DefeatText.SetActive(!playerWon);
                RestartButton.SetActive(true);
            }

        }
    }

    private bool m_playerWon;

    private bool playerWon
    {
        get { return m_playerWon; }
        set
        {
            if (value) isGameOver = true;
            m_playerWon = value;
        }
    }

    private void Start()
    {
        enemiesleft = TotalEnemies;
        isGameOver = false;
        playerWon = false;

        VictoryText.SetActive(false);
        DefeatText.SetActive(false);
        RestartButton.SetActive(false);
    }

    private void Update()
    {
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        if (enemiesleft <= 0)
        {
            playerWon = true;
            isGameOver = true; 
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1); //1 for MainScene
    }
}
