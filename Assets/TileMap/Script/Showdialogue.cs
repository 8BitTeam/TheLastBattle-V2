using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Showdialogue : MonoBehaviour
{
    public GameObject diagloguePanel;
    public TextMeshProUGUI diaglogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A) && playerIsClose)
        //{
        //    if (diagloguePanel.activeInHierarchy)
        //    {
        //        //zeroText();
        //    }
        //    else
        //    {
        //        diagloguePanel.SetActive(true);
        //       // StartCoroutine((IEnumerator)Typing());
        //    }
        //}
        //if(diaglogueText.text == dialogue[index])
        //{
        //    contButton.SetActive(true);
        //}
        if (playerIsClose)
        {
            diagloguePanel.SetActive(true);
        }
        else
        {
            diagloguePanel.SetActive(false);
        }
    }

    void zeroText()
    {
        diaglogueText.text = "";
        index = 0;
        diagloguePanel.SetActive(false);
    }
    IEnumerable Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            diaglogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        contButton.SetActive(false);
        if(index <dialogue.Length - 1)
        {
            index++;
            diaglogueText.text = "";
            StartCoroutine((IEnumerator)Typing());
        }
        else
        {
            zeroText();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("main"))
        {
            playerIsClose = true;
            k = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("main"))
        {
            playerIsClose= false;
           
            //zeroText();
        }
    }
}

