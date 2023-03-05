using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI MyscoreText;

    public int ScoreNumber;

    public GameOverScreen GameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
        ScoreNumber = 0;
        MyscoreText.text = "Coin: " + ScoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            ScoreNumber++;
            collision.gameObject.SetActive(false);
            
            MyscoreText.text = "Coin: " + ScoreNumber;
            StateNameController.scorecoin = ScoreNumber;
            GetComponent<AudioSource>().Play();          
        }
    }
    
}
