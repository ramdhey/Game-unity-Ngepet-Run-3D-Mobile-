using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    public float kecepatanputarankoin = 90f;
    
    void Update()
    {
        transform.Rotate(0,0,kecepatanputarankoin * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Babi")
        {
            gameManager.jumlahkoin += 1;
            gameObject.SetActive(false);
        }
    }
}
