using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private MainAttackScript script;
    public void StartGame()
    {
        script = GetComponent<MainAttackScript>();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    private int sceneToContinue;
    public void ContitnueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue != 0)
        {
            script.LoadPlayer();
            SceneManager.LoadScene("Final");
        }
        else
            return;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
