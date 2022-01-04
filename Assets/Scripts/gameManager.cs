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
    public static int jumlahLilin;
    public Image barLilin;
    public int maxlilin = 15;
    public int konsumsiLilinPerSec = 1;
    public ManusiaController manusiaController;

    
    public GameObject koin, lilin;

    protected override bool ShouldNotDestroyOnLoad()
    {
        return false;
    }

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        jumlahkoin = 0;
        jumlahLilin = maxlilin;

        koin.gameObject.SetActive(true);
        lilin.gameObject.SetActive(false);
        InvokeRepeating("KuranginLilin", 1f, 1f);
    }

    private void KuranginLilin()
    {
        jumlahLilin -= konsumsiLilinPerSec;
        if (jumlahLilin <= 0)
        {
            GameOver();
        }
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }

        CoinTxt.text = " " + jumlahkoin;
        barLilin.fillAmount = (float)jumlahLilin / maxlilin;
    }

    public void SwitchAvatar()
    {
        manusiaController.SwitchAvatar();
    }

    public void TambahinLilin()
    {
        jumlahLilin++;
        if (jumlahLilin > maxlilin)
        {
            jumlahLilin = maxlilin;
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}