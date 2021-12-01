using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBabi : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float zspawn = -44.34f;
    public float panjangjalan = 30f;
    public int nomorjalan = 3;

    public gameManager gameManager;

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
        GameObject g = Instantiate(roadPrefabs[roadIndex], spawnPos, transform.rotation);
        lastPos = g.transform.position;

    }
}