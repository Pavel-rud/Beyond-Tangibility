using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // public List<Transform> spawnPoints;
    public static GameObject[] BranchesPrefabs;
    public int spawnCount = 10;
    public Vector3 center;
    public Vector3 size;


    // Start is called before the first frame update
    void Start()
    {
        BranchesPrefabs = Resources.LoadAll<GameObject>("Prefabs");
        spawnBranches();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnBranches()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject branch = SpawnBranch(pos);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 255, 255, 0.5f);
        Gizmos.DrawCube(center, size);
    }



    private GameObject SpawnBranch(Vector3 spawnPoint)
    {
        var prefab = BranchesPrefabs[Random.Range(0, BranchesPrefabs.Length)];
        return Instantiate(prefab, spawnPoint, Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
    }
}
