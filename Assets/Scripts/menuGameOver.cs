using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuGameOver : MonoBehaviour
{
   public void CobaLagi()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
