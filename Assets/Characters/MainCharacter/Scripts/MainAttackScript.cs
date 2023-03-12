using Assets.ScriptsCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainAttackScript : MonoBehaviour
{
    [SerializeField]
    public int health = 100;

    [SerializeField]
    public float manaSpend = 30f;

    private TextMeshProUGUI textHP, textMana;

    HealthBar controlHealth;
    HealthBar controlDisplayMana;

    [HideInInspector]
    public Mana mana;
    Score score;
    
    public GameOverScreen gameOverScreen;

    
    
    
    //HealthBar controlHealth;
    // Start is called before the first frame update
    void Start()
    {
        mana = new Mana(manaSpend);
        controlHealth = GameObject.FindGameObjectWithTag("main_health_bar").GetComponent<HealthBar>();
        controlHealth.SetMaxHealth(health);
        controlDisplayMana = GameObject.FindGameObjectWithTag("main_mana_bar").GetComponent<HealthBar>();
        controlDisplayMana.SetMaxHealth(Mana.MANA_MAX);
        score = GetComponent<Score>();

        this.RegisterListener(EventID.OnMainHealthChange, (param)=>OnMainHealthChange());
        this.RegisterListener(EventID.OnManaChange, (param) => OnMainManaChange());
       
    }

    private void OnMainManaChange()
    {
        controlDisplayMana.SetHeatlh((int)Mathf.Floor(mana.GetMana()));
    }

    private void OnMainHealthChange()
    {
        controlHealth.SetHeatlh(health);
    }

    // Update is called once per frame
    void Update()
    {
        //controlHealth.SetHeatlh(health);
        //controlDisplayMana.SetHeatlh((int) Mathf.Floor(mana.GetMana()));
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            LoadGameOver();
        }
    }

    public void GainMana(int amount)
    {
        mana.GainMana(amount);
    }
    public void GameOver()
    {
        gameOverScreen.SetUp(score.ScoreNumber);
    }
    
    public void SavePlayer()
    {
        SaveGame.SavePlayer(this,score);
    }
    public void LoadPlayer()
    {
       PlayerData data = SaveGame.LoadPlayer();

        health = data.health;
        manaSpend = data.manaSpend;
        score.ScoreNumber = data.coinscore;

    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("SceneGO");
    }
}
