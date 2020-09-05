using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public enum SpawnState { SPAWNING, WAITING, COUNTING}

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCoundown;

    public float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Text text;
    public Text text2;

    void Start()
    {
        waveCoundown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // Check state
            if (!EnemyIsAlive())
            {
                // Begin new wave
                NextWave();
            }
            else return;
        }

        if(waveCoundown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCoundown -= Time.deltaTime;
            text.text = waveCoundown.ToString();
            text2.text = waves[nextWave].name;

        }
    }

    void NextWave()
    {
        Debug.Log("Wave DONE!");
        state = SpawnState.COUNTING;
        waveCoundown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }

        nextWave++;

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("All Enemies Down");
                return false;
            }
            //else Debug.Log("Enemy on the field.");
            
        }
        
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;


        // SPAWN WAVE
        for(int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            Debug.Log("Spawning ENEMY!");
            yield return new WaitForSeconds(1f/wave.rate);
        }


        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        // SPAWN ENEMY MECHANICS
        Instantiate(enemy, transform.position, transform.rotation);
    }

}
