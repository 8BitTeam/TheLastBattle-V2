using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    GameObject main_prefabs;

    GameObject main;
    [SerializeField]
    GameObject creep_prefabs;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;


    }
    public void ContitnueGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

        string saveMain = File.ReadAllText(Application.dataPath + "/savemain.txt");
        //List<String> mainModel = JsonConvert.DeserializeObject<List<String>>(saveMain);
        if(saveMain != null)
        {
            String[] inforMain = saveMain.Split(' ');
            main = Instantiate<GameObject>(main_prefabs, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
            main.GetComponent<MainAttackScript>().health = int.Parse(inforMain[2]);
            main.GetComponent<MainAttackScript>().manaSpend = int.Parse(inforMain[3]);
            StateNameController.scorecoin = int.Parse(inforMain[4]);
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
