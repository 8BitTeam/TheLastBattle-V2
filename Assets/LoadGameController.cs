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
    private static LoadGameController instance;
    public static LoadGameController getInstance()
    {
        if (instance == null)
        {
            instance = new LoadGameController();
        }
        return instance;
    }

    void Start()
    {
        string saveMain = File.ReadAllText(Application.dataPath + "/savemain.txt");
        //List<String> mainModel = JsonConvert.DeserializeObject<List<String>>(saveMain);
        if (saveMain != null)
        {
            String[] inforMain = saveMain.Split(' ');
            main = Instantiate<GameObject>(main_prefab, new Vector3(float.Parse(inforMain[0]), float.Parse(inforMain[1])), Quaternion.identity);
            main.GetComponent<MainAttackScript>().health = int.Parse(inforMain[2]);
            main.GetComponent<MainAttackScript>().manaSpend = int.Parse(inforMain[3]);
            StateNameController.scorecoin = int.Parse(inforMain[4]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
