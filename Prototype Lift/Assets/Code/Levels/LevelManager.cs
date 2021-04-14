using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

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
    public bool isGameOver;
    public bool isComplete = false;
    public GameObject levelBar;
    public WeaponSwitching weaponSwitching;
    public Crosshair crosshair;
    public CinemachineImpulseSource source;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        killCount = 0;

        if(PlayerPrefs.HasKey("CurrentGems")){
            gemCount = PlayerPrefs.GetInt("CurrentGems");
        }
        else{
            gemCount = 0;
        }
        
        gemText.text = gemCount.ToString();

        if(PlayerPrefs.HasKey("CurrentLevel")){
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        else{
            currentLevel = 1;
        }
        playerController = FindObjectOfType<PlayerController>();
        levelPortal = FindObjectOfType<LevelPortal>();
        waveSpawner = FindObjectOfType<WaveSpawner2>();
        weaponSwitching = FindObjectOfType<WeaponSwitching>();
        crosshair = FindObjectOfType<Crosshair>();

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

            if(!isComplete){
                FindObjectOfType<AudioManager>().stopPlaying("LevelTheme");
                levelText.text = "COMPLETE";
                levelBar.gameObject.SetActive(true);
            }
        }
    }

    public void convertToGems(){
        gemCount += killCount;
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

    public void purchaseWeapon(int weaponIdentity, GameObject purchaseParticle, int itemCost){
        if(gemCount >= itemCost && weaponIdentity != weaponSwitching.selectedWeapon){
            source.GenerateImpulse();
            gemCount -= itemCost;
            gemText.text = gemCount.ToString();

            Instantiate(purchaseParticle, playerController.transform.position, playerController.transform.rotation);
            FindObjectOfType<AudioManager>().Play("Select");

            weaponSwitching.SelectWeapon(weaponIdentity);
            crosshair.resetGun();

            PlayerPrefs.SetInt("SelectedWeapon", weaponIdentity);
        }
        else{
            //Debug.Log("insufficient amount");
            FindObjectOfType<AudioManager>().Play("Invalid");
            return;
        }
    }

    public void purchaseStatus(GameObject purchaseParticle, int itemCost){
        if(gemCount >= itemCost && playerController.currentHealth != playerController.maxHealth){
            source.GenerateImpulse();
            gemCount -= itemCost;
            gemText.text = gemCount.ToString();

            Instantiate(purchaseParticle, playerController.transform.position, playerController.transform.rotation);
            FindObjectOfType<AudioManager>().Play("PowerUp");

            playerController.currentHealth = playerController.maxHealth;
            playerController.healthBar.SetHealth(playerController.currentHealth);

        }
        else{
            //Debug.Log("insufficient amount");
            FindObjectOfType<AudioManager>().Play("Invalid");
            return;
        }
        
    }
}
