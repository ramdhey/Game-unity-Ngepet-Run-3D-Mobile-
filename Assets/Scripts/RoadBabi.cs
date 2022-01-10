using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Random = UnityEngine.Random;
using GameLokal.Toolkit;

public class RoadBabi : MonoBehaviour, IEventListener<GameEvent>
{
    public GameObject[] roadPrefabs;
    //public float zspawn = -44.34f;
    public float panjangjalan;
    public int initialJalan = 5;
    //public int nomorjalan = 3;

    public Vector3 lastPos;
    
    void OnDestroy() {
        this.EventStopListening<GameEvent>();
    }

    public void OnEvent(GameEvent gameEvent)
    {
        if(gameEvent.EventName == "jalan sudah despawn")
        {
            SpawnRoad();
        }
    }
    public void Awake()
    {
        //InvokeRepeating("SpawnRoad", 0f, 1f);
    }

    private void Start()
    {
        this.EventStartListening<GameEvent>();
        for (int i = 0; i < initialJalan; i++)
        {
            SpawnRoad();
        }
    }

    public void SpawnRoad()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos = new Vector3(lastPos.x, lastPos.y, lastPos.z + panjangjalan);

        int roadIndex = Random.Range(0, roadPrefabs.Length);
        GameObject g = Lean.Pool.LeanPool.Spawn(roadPrefabs[roadIndex], spawnPos, transform.rotation);
        lastPos = g.transform.position;
        //Debug.Log($"Spawning Road {g.name}");
    }
}