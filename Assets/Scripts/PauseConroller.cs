using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseConroller : MonoBehaviour
{
    public GameObject Pausepanel;

    public void PauseControl()
    {

        Pausepanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void Continue()
    {
        Pausepanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void HalamanSetting()
    {
        Application.LoadLevel("HalamanSetting");
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    
    public void Exit()
    {
        Application.Quit();
    }

    public void Option()
    {

        Pausepanel.SetActive(false);

       
        Time.timeScale = 0;

    }

    public void bckbtn()
    {

        Pausepanel.SetActive(true);
        Time.timeScale = 0;

    }
}
