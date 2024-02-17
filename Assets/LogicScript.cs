using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text text;
    public GameObject gameOverScreen;

    // [ContextMenu("increment")]
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
        gameOverScreen.SetActive(true);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Home");
    }
}
