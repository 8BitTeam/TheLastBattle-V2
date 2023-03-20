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
    public void Start()
    {
        controlHealth = GameObject.FindGameObjectWithTag("main_health_bar").GetComponent<HealthBar>();
        controlDisplayMana = GameObject.FindGameObjectWithTag("main_mana_bar").GetComponent<HealthBar>();

        string saveMain = File.ReadAllText(Application.dataPath + "/savemain.txt");
        string saveCreep = File.ReadAllText(Application.dataPath + "/savelistcreep.txt");
        List<CreepModel> listcreepmodel = JsonConvert.DeserializeObject<List<CreepModel>>(saveCreep);

        if (saveMain != null || saveCreep!=null)
        {
            String[] inforMain = saveMain.Split(' ');
            main = Instantiate<GameObject>(main_prefab, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
            controlHealth.SetHeatlh(int.Parse(inforMain[2]));

            controlDisplayMana.SetHeatlh(int.Parse(inforMain[3]));
            StateNameController.scorecoin = int.Parse(inforMain[4]);

            foreach (CreepModel cm in listcreepmodel)
            {
                
                if (cm.name.Equals("goblin"))
                {
                    factory = new GoblinFactory();
                }
                else if (cm.name.Equals("worm"))
                {
                    factory = new WormFactory();
                }
                else
                {
                    Debug.Log("None Giant");
                }
                Vector2 location_creep = new Vector2(cm.x, cm.y);
                Creep creep = factory.CreateCreep(location_creep);
                healthBar = creep.gameObject.transform.Find("ControlHealthCreep").gameObject;
                controlHealthCreep = healthBar.GetComponent<HealthBar>();
                controlHealthCreep.SetHeatlh(cm.health);

                //creep.health = cm.health;

                //creep = Instantiate<GameObject>(creep_prefab, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
                //creep.GetComponent<MainAttackScript>().health = int.Parse(inforMain[2]);

            }
        }
        else
        {
            main = Instantiate<GameObject>(main_prefab, new Vector3(0f, 0f), Quaternion.identity);
            controlHealth.SetHeatlh(100);
            controlDisplayMana.SetHeatlh(0);
            StateNameController.scorecoin = 0;
        }
    }


    // Update is called once per frame
}
