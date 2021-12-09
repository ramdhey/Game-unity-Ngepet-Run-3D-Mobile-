using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;
    public static int jumlahkoin;
    public Text CoinTxt;
    public Text LilinText;
    public static int jumlahLilin;

    public GameObject manusia, babi;
    public GameObject koin, lilin;
    int whichAvatarIsOn = 2;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        jumlahkoin = 0;

        babi.gameObject.SetActive(true);
        koin.gameObject.SetActive(true);

        manusia.gameObject.SetActive(false);
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
        switch (whichAvatarIsOn)
        {
            case 1:
                whichAvatarIsOn = 2;
                babi.SetActive(false);
                koin.gameObject.SetActive(false);

                manusia.SetActive(true);
                lilin.gameObject.SetActive(true);
                break;

            case 2:
                whichAvatarIsOn = 1;
                babi.SetActive(true);
                koin.gameObject.SetActive(true);

                manusia.SetActive(false);
                lilin.gameObject.SetActive(false);
                break;
        }
    }
}