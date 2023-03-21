using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("enableLoad", 1);
    }
    public void ContitnueGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("enableLoad", 2);
       // LoadGameController.getInstance();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
