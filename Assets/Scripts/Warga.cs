using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warga : MonoBehaviour
{
    Animator anim;
    public GameObject warga;
    public float triggerDistance = 15f;

    gameManager gameManager;
    private GameObject player;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if ((warga.transform.position - player.transform.position).magnitude < triggerDistance)
        {
            StartCoroutine("catchBabi");
        }
    }

    IEnumerator catchBabi()
    {
        anim.SetTrigger("isCatching");
        yield return new WaitForSeconds(1);

        if (BabiController.whichAvatarIsOn == 1)
        {
            gameManager.Instance.GameOver();
        }
    }
}
