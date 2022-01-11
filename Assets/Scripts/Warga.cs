using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warga : MonoBehaviour
{
    Animator anim;
    public GameObject warga;
    public float triggerDistance = 15f;

    gameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GameObject babi = GameObject.FindGameObjectWithTag("Babi");

        if ((warga.transform.position - babi.transform.position).magnitude < triggerDistance)
        {
            StartCoroutine("catchBabi");
        }
    }

    IEnumerator catchBabi()
    {
        anim.SetTrigger("isCatching");
        yield return new WaitForSeconds(1);
        gameManager.gameOver = true;
    }
}
