using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int enemiesAvailable;
    public LevelManager levelManager;
    public enum SpawnState{
        SPAWNING,
        WAITING,
        COUNTING
    }

    [System.Serializable]
    public class Wave{
        public string name;
        public Transform[] enemies;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform[] enemies;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    
    private float searchCountdown = 1f; 

    public SpawnState state = SpawnState.COUNTING;

    void Awake() {
        waveCountDown = timeBetweenWaves;
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Update() {
        if(state == SpawnState.WAITING){
            if(!enemyIsAlive()){
                // begin a new round
                Debug.Log("Wave Complete");
            }
            else{
                return;
            }
        }

        if(waveCountDown <= 0){
            if(state != SpawnState.SPAWNING){
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else{
            waveCountDown -= Time.deltaTime;
        }
    }

    bool enemyIsAlive(){
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0){
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true; 
    }

    IEnumerator SpawnWave(Wave _wave){
        
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //spawn
        for(int i = 0; i < _wave.count; i++){
            SpawnEnemy(_wave.enemies);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform[] enemies){
        // Spawn enemy
        //Debug.Log("Spawning enemy: " + _enemy.name);
        int x = Random.Range(0,enemies.Length);
        Instantiate(enemies[x], transform.position, transform.rotation); // spawns enemy at position
    }

    public void LevelComplete(){
        gameObject.SetActive(false);
    }
}
