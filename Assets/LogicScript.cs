using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text text;
    public GameObject gameOverScreen;
    private int _highScore;
    public TextMeshProUGUI highScoreObj;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            var highScore = PlayerPrefs.GetInt("highScore");
            highScoreObj.text = highScore.ToString();
            _highScore = highScore;
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void Increment()
    {
        score += 1;
        text.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (score > _highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreObj.text = score.ToString();
        }
        gameOverScreen.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Home");
    }
}
