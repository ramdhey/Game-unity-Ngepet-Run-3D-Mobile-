using System;
using System.Collections;
using System.Collections.Generic;
using GameLokal.Toolkit;
using UnityEngine;

public class Collectibles : MonoBehaviour, IEventListener<GameEvent>
{
    public GameObject coin;
    public GameObject lilin;

    private int mode;

    private void OnDestroy()
    {
        EventManager.RemoveListener(this);
    }

    private void Start()
    {
        Ubah(BabiController.whichAvatarIsOn);
        EventManager.AddListener(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TambahinValue();
            
        }
        
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void TambahinValue()
    {
        if (mode == 1)
        {
            gameManager.jumlahkoin++;
            sfxman.Instance.sfx.PlayOneShot(sfxman.Instance.koin);

        }
        else
        {
            gameManager.Instance.TambahinLilin();
            sfxman.Instance.sfx.PlayOneShot(sfxman.Instance.lilin);

        }

        Destroy(gameObject);
    }

    public void Ubah(int i)
    {
        mode = i;
        if (i == 1)
        {
            coin.SetActive(true);
            lilin.SetActive(false);
        }
        else
        {
            coin.SetActive(false);
            lilin.SetActive(true);
        }
    }

    public void OnEvent(GameEvent e)
    {
        if (e.EventName == "Jadi Manusia")
        {
            Ubah(2);
        }
        else if (e.EventName == "Jadi Babi")
        {
            Ubah(1);
        }
    }
}
