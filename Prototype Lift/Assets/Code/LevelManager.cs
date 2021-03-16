using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int killCount, killGoal;
    public int gemCount;
    public int currentLevel;
    public int enemiesAvailable;
    public PlayerController playerController;
    public TextMeshProUGUI killText, gemText, levelText;
    public Color levelCompleteColour;
    public LevelPortal levelPortal;
    public WaveSpawner2 waveSpawner;
    public float pauseTime;
    public GameObject gameOverUI;
    public bool isGameOver = false;
    public GameObject levelBar;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        gemCount = 0;
        //currentLevel = 1;
        playerController = FindObjectOfType<PlayerController>();
        levelPortal = FindObjectOfType<LevelPortal>();
        waveSpawner = FindObjectOfType<WaveSpawner2>();

        updateKillGoal();
        killText.text = killCount.ToString() + "/" + killGoal.ToString();
        killText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKills(){
        if(killCount < killGoal){
            killCount++;
            killText.text = killCount.ToString() + "/" + killGoal.ToString();
        }
        if(killCount >= killGoal){
            killText.color = levelCompleteColour;
            waveSpawner.LevelComplete();
            levelPortal.activatePortal();

            levelText.text = "COMPLETE";
            levelBar.gameObject.SetActive(true);
        }
    }

    public void convertToGems(){
        gemCount = killCount;
        killCount = 0;
    }

    public IEnumerator gameOver(){
        isGameOver = true;
        waveSpawner.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void goToNextLevel(){
        currentLevel++;
        updateKillGoal();
    }

    public void updateKillGoal(){
        switch(currentLevel){
            case 1:
                killGoal = 10;
                enemiesAvailable = 1;
                break;
            case 2:
                killGoal = 20;
                enemiesAvailable = 2;
                break;
            case 3:
                killGoal = 30;
                enemiesAvailable = 3;
                break;
            case 4:
                killGoal = 40;
                enemiesAvailable = 3;
                break;
            case 5:
                killGoal = 50;
                enemiesAvailable = 4;
                break;
            default:
                killGoal = 60;
                enemiesAvailable = 4;
                break;
        }
    }

    public void updateProgress(){
        levelText.text = currentLevel.ToString() + "-" + waveSpawner.currentWave.ToString();
        levelBar.gameObject.SetActive(true);
    }

}
