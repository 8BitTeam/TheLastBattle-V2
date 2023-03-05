using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    public TextMeshProUGUI MyscoreText;
    public int coinscore;
    // Start is called before the first frame update
    void Start()
    {
        coinscore = StateNameController.scorecoin;
        SetUp(coinscore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUp(int score)
    {
       
        MyscoreText.text = "You have "+ score.ToString()+" coins";
    }
    public void ShowScore()
    {

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Final");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
