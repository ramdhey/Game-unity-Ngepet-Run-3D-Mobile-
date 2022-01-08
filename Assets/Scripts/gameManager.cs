using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using GameLokal.Toolkit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : Singleton<gameManager>
{
    public TextMeshProUGUI livescore;
    public TextMeshProUGUI scoretxt;
    public float scoreCount;
    public float scorePersecond;
    public bool scoreIncreasing;

    public TextMeshProUGUI Hiscore;
    public float HiscoreCount;

    public TextMeshProUGUI CoinGOTxt;

    public static bool gameOver;
    public GameObject GameOverPanel;
    public static int jumlahkoin;
    public TextMeshProUGUI CoinTxt;
    public static int jumlahLilin;
    public Image barLilin;
    public int maxlilin = 15;
    public int konsumsiLilinPerSec = 1;
    public BabiController manusiaController;

    
    public GameObject koin, lilin;

    protected override bool ShouldNotDestroyOnLoad()
    {
        return false;
    }

   

    void Start()
    {
        if (PlayerPrefs.HasKey(""))
        {
            HiscoreCount = PlayerPrefs.GetFloat("");
        }

        

        gameOver = false;
        Time.timeScale = 1;
        



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

//ScoreManager
        if (scoreIncreasing)
        {
            scoreCount += scorePersecond * Time.deltaTime;
        }
        if (scoreCount > HiscoreCount)
        {
            HiscoreCount = scoreCount;
            PlayerPrefs.SetFloat("", HiscoreCount);
        }

        livescore.text = "  " + Mathf.Round(scoreCount);
        Hiscore.text = "" + Mathf.Round(HiscoreCount);



        if (gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            
            scoretxt.text = "  " + Mathf.Round(scoreCount);
            CoinGOTxt.text = " " + jumlahkoin;
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