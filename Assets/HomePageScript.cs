using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
