using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameController : MonoBehaviour
{
    [SerializeField]
    GameObject main_prefab;

    GameObject main;

    HealthBar controlHealth;
    HealthBar controlDisplayMana;
    private static NewGameController instance;
    public static NewGameController getInstance()
    {
        if (instance == null)
        {
            instance = new NewGameController();
        }
        return instance;
    }
    public void StartGame()
    {
        controlHealth = GameObject.FindGameObjectWithTag("main_health_bar").GetComponent<HealthBar>();
        controlDisplayMana = GameObject.FindGameObjectWithTag("main_mana_bar").GetComponent<HealthBar>();

        main = Instantiate<GameObject>(main_prefab, new Vector3(0f, 0f), Quaternion.identity);
        controlHealth.SetHeatlh(100);
        controlDisplayMana.SetHeatlh(0);
        StateNameController.scorecoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
