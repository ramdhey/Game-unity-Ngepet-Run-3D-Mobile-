using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Jalan"))
        {
            Debug.Log($"Despawn{other.name}");
            LeanPool.Despawn(other.gameObject);
        }
    }
}
