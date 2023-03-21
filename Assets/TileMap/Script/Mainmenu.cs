using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Newtonsoft.Json;

public class Mainmenu : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenuScreen;
    // Start is called before the first frame update

    private int currentScenceIndex;


    
    List<CreepModel> listcreepjson = new List<CreepModel>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToHomeMenu()
    {
        currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScenceIndex);
        SceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    
    public void SaveGame()
    {
        AddCreepToList();
        string data = "";
        data = JsonConvert.SerializeObject(listcreepjson);
      // data = JsonConvert.SerializeObject(listcreepjson);
        File.WriteAllText(Application.dataPath + "/savelistcreep.txt", data);

        GameObject main = GameObject.FindGameObjectWithTag("main");
        string data2 = "";
        if (main != null)
        {
            MainModel mainModel = new MainModel();
            string x = main.gameObject.transform.position.x + "";
            string y = main.gameObject.transform.position.y + "";
            string health = main.gameObject.GetComponent<MainAttackScript>().health+"";
            string mana = main.gameObject.GetComponent<MainAttackScript>().manaSpend+"";
            
            string score = StateNameController.scorecoin + "";
            data2 = x + " " + y + " " + health + " " + mana + " " + score+" ";
            File.WriteAllText(Application.dataPath + "/savemain.txt", data2);
        }
    }
    void AddCreepToList()
    {
        GameObject[] listgoblin = GameObject.FindGameObjectsWithTag("goblin");
        GameObject[] listworm = GameObject.FindGameObjectsWithTag("worm");
        List<GameObject> listcreep = new List<GameObject>();
        foreach(GameObject go in listgoblin)
        {
            listcreep.Add(go);
        }
        foreach (GameObject go in listworm)
        {
            listcreep.Add(go);
        }
        if (listcreep.Count != 0)
        {
            foreach (GameObject cre in listcreep)
            {
                CreepModel model = new CreepModel();
                model.Name = cre.gameObject.tag;
                model.X = cre.gameObject.transform.position.x;
                model.Y = cre.gameObject.transform.position.y;

                if (cre.gameObject.GetComponent<Goblin>() != null)
                {
                    model.Health = cre.gameObject.GetComponent<Goblin>().health;  
                }
                else
                {
                    model.Health = cre.gameObject.GetComponent<Worm>().health;
                }
                listcreepjson.Add(model);
                //CreepLocationInfo creep = new CreepLocationInfo();
                //creep.positionx = cre.transform.position.x;
                //creep.positiony = cre.transform.position.y;
                //creeps.Add(creep);
            }
        }
    }
}
