using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babi : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
