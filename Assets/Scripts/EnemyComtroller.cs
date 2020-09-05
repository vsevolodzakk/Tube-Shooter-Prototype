using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComtroller : MonoBehaviour
{
    public GameObject enemyParent;
    private GameObject enemy;

    public Transform spawnLocation;
    private Quaternion direction;

    public float spawnCounter = 0f;
    public float enemyCount = 0f;

    void Update()
    {
        spawnCounter++;
        if (spawnCounter >= 75f && enemyCount <= 5 && enemyCount >= 0)
        {
            Spawn();
            enemyCount++;
        }
        

    }

    private void Spawn()
    {
        Instantiate(enemyParent, spawnLocation.position, direction);
        spawnCounter = 0f;

    }
}
