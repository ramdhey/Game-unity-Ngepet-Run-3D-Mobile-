using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxman : MonoBehaviour
{
    public static sfxman Instance { get; set; }

    public AudioSource sumbernya;
    public AudioClip loncat;
    public AudioClip ndlosor;
    public AudioClip geser;
    public AudioClip koin;
    public AudioClip lilin;
    public AudioClip gameover;
    public AudioClip ketangkep;



    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
