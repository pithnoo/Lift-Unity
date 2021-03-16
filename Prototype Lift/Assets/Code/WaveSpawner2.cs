using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner2 : MonoBehaviour
{
    [System.Serializable]
    public class level{
        //public int killGoal;
        public string name;
        public float timeBetweenWaves;
        public int count;
        public float rate;
        public GameObject[] enemies;
    }

    public enum SpawnState{
        WAITING,
        SPAWNING,
        COUNTING
    }

    public SpawnState state = SpawnState.COUNTING;
    public LevelManager levelManager;
    public float waveCountDown;
    private float searchCountdown = 1f;
    public level[] levels;
    public int currentLevel;
    public int currentWave;
    public LevelPortal levelPortal;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        currentLevel = levelManager.currentLevel - 1;
        waveCountDown = levels[currentLevel].timeBetweenWaves;
        levelPortal = FindObjectOfType<LevelPortal>();
        levelManager.updateProgress();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.WAITING){
            if(!enemyIsAlive()){
                //complete wave
                Debug.Log("Wave complete");
                currentWave++;
                levelManager.updateProgress();
                waveCountDown = levels[currentLevel].timeBetweenWaves;
                state = SpawnState.COUNTING;
            }
            else{
                return;
            }
        }

        if(waveCountDown <= 0){
            if(state != SpawnState.SPAWNING){
                StartCoroutine(SpawnWave(levels[currentLevel]));
            }
        }
        else{
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(level _level){
        
        //Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        levelPortal.spawningEnemies();

        //spawn
        for(int i = 0; i < _level.count; i++){
            SpawnEnemy(_level.enemies);
            yield return new WaitForSeconds(1f/_level.rate);
        }

        state = SpawnState.WAITING;
        levelPortal.stopSpawning();
        yield break;
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

    void SpawnEnemy(GameObject[] enemies){
        // Spawn enemy
        //Debug.Log("Spawning enemy: " + _enemy.name);
        int x = Random.Range(0,enemies.Length);
        Instantiate(enemies[x], transform.position, transform.rotation); // spawns enemy at position
    }

    public void LevelComplete(){
        gameObject.SetActive(false);
    }
}
