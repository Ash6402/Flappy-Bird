using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text text;
    public GameObject gameOverScreen;
    private int highScore;
    public TextMeshProUGUI highScoreObj;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int _highScore = PlayerPrefs.GetInt("highScore");
            highScoreObj.text = _highScore.ToString();
            highScore = _highScore;
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void increment()
    {
        score += 1;
        text.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreObj.text = score.ToString();
        }
        gameOverScreen.SetActive(true);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Home");
    }
}
