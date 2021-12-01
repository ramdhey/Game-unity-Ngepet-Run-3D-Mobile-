using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Random = UnityEngine.Random;

public class RoadBabi : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    //public float zspawn = -44.34f;
    public float panjangjalan = 30f;
    public int initialJalan = 5;
    //public int nomorjalan = 3;

    public Vector3 lastPos;

    //public void Awake()
    //{
    //    InvokeRepeating("SpawnRoad", 1f, 1f);
    //}

    private void Start()
    {
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
    }
}