using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hantu : MonoBehaviour
{

    public Animator anim;
    public GameObject hantu;

    public float activationDistance = 20f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hantu.SetActive(true);
    }

    void Update()
    {
        GameObject manusia = GameObject.FindGameObjectWithTag("manusia");

        if ((hantu.transform.position - manusia.transform.position).magnitude < activationDistance)
        {
            hantu.SetActive(true);
        }
        else if (manusia.activeInHierarchy == false)
        {
            hantu.SetActive(false);
        }
    }
}
