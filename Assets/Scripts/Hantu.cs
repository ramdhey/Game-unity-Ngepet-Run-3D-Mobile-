using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hantu : MonoBehaviour
{

    public Animator anim;
    public GameObject hantu;

    public float activationDistance = 20f;
    private GameObject player;
    private bool isFly;
    private float initialY;
    private bool obstacleActive;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        initialY = hantu.transform.position.y;
    }

    private void OnEnable()
    {
        isFly = false;
        var currentTransform = hantu.transform.position;
        currentTransform.y = initialY;
        hantu.transform.position = currentTransform;
        obstacleActive = true;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if ((hantu.transform.position - player.transform.position).magnitude < activationDistance && obstacleActive)
        {
            CheckModeKarakterPlayer();
        }

        if (isFly)
        {
            hantu.transform.Translate(0f, 20f * Time.deltaTime, 0f);
        }
    }
    
    private void CheckModeKarakterPlayer()
    {
        // Karakter lagi jadi manusia
        if (BabiController.whichAvatarIsOn == 2)
        {
            GameOver();
        }
        
        // Karakter lagi jadi Babi
        if (BabiController.whichAvatarIsOn == 1)
        {
            Menghilang();
        }
        
        obstacleActive = false;
    }
    
    private void GameOver()
    {
        gameManager.Instance.GameOver();
    }

    private void Menghilang()
    {
        isFly = true;
    }
}
