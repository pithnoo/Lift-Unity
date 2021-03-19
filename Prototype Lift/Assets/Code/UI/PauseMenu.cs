using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public LevelManager levelManager;
    public LevelLoader levelLoader;
    public AudioManager audioManager;

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        levelLoader = FindObjectOfType<LevelLoader>();
        //audioManager = FindObjectOfType<AudioManager>();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !levelManager.isGameOver){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        FindObjectOfType<AudioManager>().Play("Pause");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause(){
        FindObjectOfType<AudioManager>().Play("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu(){

        if(FindObjectOfType<PlayerController>() != null){
            FindObjectOfType<PlayerController>().invincible = true;
        }
        
        FindObjectOfType<AudioManager>().Play("Select");
        levelLoader.loadLevel(0);
        FindObjectOfType<AudioManager>().Play("MenuTheme");
        Time.timeScale = 1;
    }

    public void QuitGame(){
        //audioManager.Play("Pause");
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
