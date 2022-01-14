using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "manusia")
        {
            gameManager.jumlahLilin += 1;
            
            gameObject.SetActive(false);
        }
    }
}
