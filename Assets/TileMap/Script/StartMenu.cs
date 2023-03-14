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
        SceneManager.LoadScene(1);
        Time.timeScale = 1;


    }
    public void ContitnueGame()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;

        LoadGameController loadGame = LoadGameController.getInstance();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
