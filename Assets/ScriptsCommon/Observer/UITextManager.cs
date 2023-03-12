using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextManager : MonoBehaviour
{
    public int numberOfCoins = 0;
    [SerializeField]
    TextMeshProUGUI coinOnText;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        coinOnText.gameObject.SetActive(false);
        this.RegisterListener(EventID.OnCoinCollect, (param) => OnCoinCollect());
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2f;
        timer.Run();
    }

    private void OnCoinCollect()
    {
        coinOnText.gameObject.SetActive(true);
        numberOfCoins++;
        coinOnText.text = "You have " + numberOfCoins.ToString()+"coins";
        StateNameController.scorecoin = numberOfCoins;
    }
    private void Update()
    {
        if (timer.Finished)
        {
            coinOnText.gameObject.SetActive(false);
            timer.Run();
        }
    }
}
