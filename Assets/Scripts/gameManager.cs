using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using GameLokal.Toolkit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : Singleton<gameManager>
{
    public static bool gameOver;
    public GameObject GameOverPanel;
    public static int jumlahkoin;
    public TextMeshProUGUI CoinTxt;
    public TextMeshProUGUI LilinText;
    public static int jumlahLilin;
    public ManusiaController manusiaController;

    
    public GameObject koin, lilin;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        jumlahkoin = 0;

        koin.gameObject.SetActive(true);
        lilin.gameObject.SetActive(false);
    }


    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }

        CoinTxt.text = " " + jumlahkoin;
        LilinText.text = " " + jumlahLilin;
    }

    public void SwitchAvatar()
    {
        manusiaController.SwitchAvatar();
    }
}