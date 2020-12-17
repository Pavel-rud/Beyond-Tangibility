﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // public List<Transform> spawnPoints;
    public static GameObject[] StonesPrefabs;
    public int spawnCount = 1;
    public Vector3 center;
    public Vector3 size;


    // Start is called before the first frame update
    void Start()
    {
        StonesPrefabs = Resources.LoadAll<GameObject>("Prefabs");
        spawnStones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnStones()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject stone = spawnStone(pos);
            Rigidbody stone_rigidbody = stone.AddComponent<Rigidbody>();
            stone.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            BoxCollider stone_colider = stone.AddComponent<BoxCollider>();
            stone_rigidbody.mass = 2f;
            stone.name = "stone_" + i;
        }
    }

    private GameObject spawnStone(Vector3 spawnPoint)
    {
        var prefab = StonesPrefabs[Random.Range(0, StonesPrefabs.Length)];
        return Instantiate(prefab, spawnPoint, Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
    }
}
