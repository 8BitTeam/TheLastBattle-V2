using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadGameController : MonoBehaviour
{
    [SerializeField]
    GameObject main_prefab;

    GameObject main;
    GameObject healthBar;
    HealthBar controlHealth, controlHealthCreep;
    HealthBar controlDisplayMana;

    private static LoadGameController instance;
    public static LoadGameController getInstance()
    {
        if (instance == null)
        {
            instance = new LoadGameController();
        }
        return instance;
    }
    AbstractFactory factory;
    string saveMain, saveCreep;
    public void Start()
    {
        controlHealth = GameObject.FindGameObjectWithTag("main_health_bar").GetComponent<HealthBar>();
        controlDisplayMana = GameObject.FindGameObjectWithTag("main_mana_bar").GetComponent<HealthBar>();

         saveMain = File.ReadAllText(Application.dataPath + "/savemain.txt");
         saveCreep = File.ReadAllText(Application.dataPath + "/savelistcreep.txt");

        int enable = PlayerPrefs.GetInt("enableLoad")==1 ? 1 : PlayerPrefs.GetInt("enableLoad");

        if (enable == 1)
        {
            NewGame();
        }
        else
        {
            Load();
        }
        
    }
    void Load()
    {
        List<CreepModel> listcreepmodel = JsonConvert.DeserializeObject<List<CreepModel>>(saveCreep);

        if (saveMain != null || saveCreep != null)
        {
            String[] inforMain = saveMain.Split(' ');
            main = Instantiate<GameObject>(main_prefab, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
            controlHealth.SetHeatlh(int.Parse(inforMain[2]));

            controlDisplayMana.SetHeatlh(int.Parse(inforMain[3]));
            StateNameController.scorecoin = int.Parse(inforMain[4]);

            foreach (CreepModel cm in listcreepmodel)
            {

                if (cm.Name.Equals("goblin"))
                {
                    factory = new GoblinFactory();
                }
                else if (cm.Name.Equals("worm"))
                {
                    factory = new WormFactory();
                }
                else
                {
                    Debug.Log("None Giant");
                }
                Vector2 location_creep = new Vector2(cm.X, cm.Y);
                Creep creep = factory.CreateCreep(location_creep);
                if (creep != null)
                    Debug.Log("Has created");
                //Debug.Log(creep.gameObject.transform.position);
                //healthBar = creep.gameObject.transform.Find("ControlHealthCreep").gameObject;
                //controlHealthCreep = healthBar.GetComponent<HealthBar>();
                //controlHealthCreep.SetHeatlh(cm.health);

                //creep.health = cm.health;

                //creep = Instantiate<GameObject>(creep_prefab, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
                //creep.GetComponent<MainAttackScript>().health = int.Parse(inforMain[2]);

            }
            
        }
        else
        {
            NewGame();
        }
    }
    void NewGame()
    {
        main = Instantiate<GameObject>(main_prefab, new Vector3(0f, 0f), Quaternion.identity);
        controlHealth.SetHeatlh(100);
        controlDisplayMana.SetHeatlh(0);
        StateNameController.scorecoin = 0;
    }
}
