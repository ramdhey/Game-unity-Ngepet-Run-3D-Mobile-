using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Random = UnityEngine.Random;
using GameLokal.Toolkit;

public class ItemCollectibles : MonoBehaviour, IEventListener<GameEvent>
{
    public GameObject[] ItemPrefabs;
    public int initialPrefabs = 5;
    public float itemLengths;

    public Vector3 lastPos;

    void OnEnable() {
        this.EventStartListening<GameEvent>();
    }

    void OnDisable() {
        this.EventStopListening<GameEvent>();
    }

    public void OnEvent(GameEvent gameEvent)
    {
        if(gameEvent.EventName == "jalan item sudah despawn")
        {
            spawnItem();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialPrefabs; i++)
        {
            spawnItem();
        }
    }

    public void spawnItem()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos = new Vector3(lastPos.x, lastPos.y, lastPos.z + itemLengths);

        int itemIndex = Random.Range(0, ItemPrefabs.Length);
        GameObject obj = Lean.Pool.LeanPool.Spawn(ItemPrefabs[itemIndex], spawnPos, transform.rotation);
        lastPos = obj.transform.position;   
        Debug.Log($"Spawning Road Item {obj.name}");
    }
}
