using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;

public class Mainmenu : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenuScreen;
    // Start is called before the first frame update

    private int currentScenceIndex;
    GameObject main,machineGun,shotGun;
    bool change = false;

    List<CreepModel> listcreepjson = new List<CreepModel>();
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("main");
        machineGun = GameObject.FindGameObjectWithTag("machinegun");
        shotGun = GameObject.Find("ShotGun");
        shotGun.SetActive(false);
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
    public void ShowClick()
    {
        if (!change)
        {

            machineGun.SetActive(false);
            shotGun.SetActive(true);
            change = true;
        }
        else
        {

            machineGun.SetActive(true);
            shotGun.SetActive(false);
            change = false;
        }
    }
    public void SaveGame()
    {
        AddCreepToList();
        string data = "";
        //JsonConvert
       data = JsonConvert.SerializeObject(listcreepjson);
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
        GameObject[] listcreep = GameObject.FindGameObjectsWithTag("creep");
        if (listcreep.Length != 0)
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
