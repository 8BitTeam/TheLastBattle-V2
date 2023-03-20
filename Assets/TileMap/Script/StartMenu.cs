using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(3,LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    public void ContitnueGame()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;

       LoadGameController.getInstance();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
