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
    public Transform[] spwanPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    public float lifeTime;
    private float searchCountDown = 1f;
    public SpwanState state = SpwanState.COUNTING;
         
    void Start()
    {
        lifeTime = 15f;

       // Invoke("DestroySpawnEnemy", lifeTime); 
        if (spwanPoints.Length == 0)
        {
            Debug.LogError("No Spwan points referenced");
        }
        waveCountDown = timeBetweenWaves;
    }
    void Update()
    {
        if (state == SpwanState.WAITING)
        {
            //check enemies still alive
            if(!EnemyIsAlive())
            {
                // Spwan Enemies now
                WaveCompleted();
            }
            else
            {
                return;
            }

        }
        if (waveCountDown <= 0)
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
    void WaveCompleted()
    {
        //Debug.Log("Completed");
        state = SpwanState.COUNTING;
        waveCountDown = timeBetweenWaves;
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            //Debug.Log("All waves completed");
        }
        else
            nextWave++;
    }
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
       
        return true;
    }
    IEnumerator SpwanWave(Wave _wave)
    {
        //ssDebug.Log("Spwaning Wave:" + _wave.name);
        state = SpwanState.SPWANING;
        //spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            // yield return new WaitForSeconds(1f/ _wave.rate);
        }
        state = SpwanState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spwaning Enemy :" + _enemy.name);
        
        Transform _sp = spwanPoints[Random.Range(0, spwanPoints.Length)];
        Instantiate(_enemy, transform.position, transform.rotation);
    }
    void DestroySpawnEnemy()
    {
        Destroy(gameObject);
    }
}
