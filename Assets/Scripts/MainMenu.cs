using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static int jumlahkoin;
    public TextMeshProUGUI CoinTxt;


    public void Awake()
    {
        jumlahkoin = PlayerPrefs.GetInt("jumlahkoin", 0);

        UpdateUI();
    }
    public void UpdateUI()
    {
        CoinTxt.text = gameManager.jumlahkoin+(" ") ;
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();

    }

}
