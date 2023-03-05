using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenuScreen;
    // Start is called before the first frame update

    private int currentScenceIndex;
    GameObject main,machineGun,shotGun;
    bool change = false;
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
}
