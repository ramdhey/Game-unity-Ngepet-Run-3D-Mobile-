using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using GameLokal.Toolkit;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Jalan"))
        {
            Debug.Log($"Despawn{other.name}");
            GameEvent.Trigger("jalan sudah despawn");
            LeanPool.Despawn(other.gameObject);
        }
    }
}
