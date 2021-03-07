using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int killCount, killGoal;
    public int gemCount;
    public int currentLevel;
    public PlayerController playerController;
    public TextMeshProUGUI killText, gemText;
    public Color levelCompleteColour;
    public LevelPortal levelPortal;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        gemCount = 0;
        currentLevel = 1;
        playerController = FindObjectOfType<PlayerController>();
        levelPortal = FindObjectOfType<LevelPortal>();

        updateKillGoal();
        killText.text = killCount.ToString() + "/" + killGoal.ToString();
        killText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKills(){
        killCount++;
        killText.text = killCount.ToString() + "/" + killGoal.ToString();
        if(killCount >= killGoal){
            killText.color = levelCompleteColour;
            levelPortal.activatePortal();
        }
    }

    public void convertToGems(){
        gemCount = killCount;
        killCount = 0;
    }

    public IEnumerator gameOver(){
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
    }

    public void goToNextLevel(){
        currentLevel++;
        updateKillGoal();
    }

    public void updateKillGoal(){
        switch(currentLevel){
            case 1:
                killGoal = 10;
                break;
            case 2:
                killGoal = 20;
                break;
            case 3:
                killGoal = 30;
                break;
            case 4:
                killGoal = 40;
                break;
            case 5:
                killGoal = 50;
                break;
        }
    }


}
