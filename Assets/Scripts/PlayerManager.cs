using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;
    public static int jumlahkoin;
    public Text CoinTxt;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        jumlahkoin = 0;
        
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
        CoinTxt.text = " " + jumlahkoin;
        
    }
}
