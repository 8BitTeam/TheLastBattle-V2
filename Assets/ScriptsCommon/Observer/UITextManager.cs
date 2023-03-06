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
    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(EventID.OnCoinCollect, (param) => OnCoinCollect());
    }

    private void OnCoinCollect()
    {
        numberOfCoins++;
        coinOnText.text = "You have " + numberOfCoins.ToString();
    }

}
