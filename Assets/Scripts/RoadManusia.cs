using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManusia : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    //public float zspawn = -44.34f;
    public float panjangjalan = 30f;
    //public int nomorjalan = 3;

    public Vector3 lastPos;

    public void Awake()
    {
    InvokeRepeating("SpawnRoad", 1f, 1f);
    }

    public void SpawnRoad()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos = new Vector3(lastPos.x, lastPos.y, lastPos.z + panjangjalan);

        int roadIndex = Random.Range(0, roadPrefabs.Length);
        GameObject r = Instantiate(roadPrefabs[roadIndex], spawnPos, transform.rotation);
        lastPos = r.transform.position;
    }

}
