using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpwanState { SPWANING, WAITING, COUNTING  };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;


    }
    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public SpwanState state = SpwanState.COUNTING;
         
    
    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }
    void Update()
    {
        if(waveCountDown <= 0)
        {
            if (state != SpwanState.SPWANING)
            {
                // start spwaning
                StartCoroutine(SpwanWave (waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpwanWave(Wave _wave)
    {
        state = SpwanState.SPWANING;
        //spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
        //    yield retrun new WaitForSeconds(1f/_wave.rate);
        }
        state = SpwanState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spwaning Enemy :" + _enemy.name);
    }
}
