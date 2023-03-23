using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("enableLoad", 1);
    }
    public void ContitnueGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("enableLoad", 2);
       // LoadGameController.getInstance();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
