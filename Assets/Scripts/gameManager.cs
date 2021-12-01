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
    public GameObject jalanManusia, jalanBabi;
    int whichAvatarIsOn = 1;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        jumlahkoin = 0;

        babi.gameObject.SetActive(true);
        jalanBabi.gameObject.SetActive(true);

        manusia.gameObject.SetActive(false);
        jalanManusia.gameObject.SetActive(false);
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
                jalanBabi.SetActive(false);
                destroyCoin();

                manusia.SetActive(true);
                jalanManusia.SetActive(true);
                break;

            case 2:
                whichAvatarIsOn = 1;
                babi.SetActive(true);
                jalanBabi.SetActive(true);

                manusia.SetActive(false);
                jalanManusia.SetActive(false);
                destroyLilin();

                break;
        }
    }

    public void destroyCoin()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject coin in objectsToDestroy)
        {
            Destroy(coin);
        }
    }
    public void destroyLilin()
    {
        GameObject[] destroyObjects = GameObject.FindGameObjectsWithTag("lilin");
        foreach (GameObject lilin in destroyObjects)
        {
            Destroy(lilin);
        }
    }
}